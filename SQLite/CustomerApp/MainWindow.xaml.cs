using CustomerApp.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        private byte[] picture;
        string filePath = "";

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        // 値を入力してSave
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                MessageBox.Show("名前が未入力です。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();

                // 重複確認 (名前、電話番号、住所が一致する顧客が存在するか)
                var existingCustomer = connection.Table<Customer>().FirstOrDefault(c =>
                    c.Name == NameTextBox.Text &&
                    c.Phone == PhoneTextBox.Text &&
                    c.Address == AddressTextBox.Text);

                if (existingCustomer != null) {
                    MessageBox.Show("この顧客はすでに登録されています。", "登録エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // 新しい顧客を登録
                var customer = new Customer {
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text
                };

                // 画像を登録
                if (!string.IsNullOrEmpty(filePath)) {
                    Bitmap bmp = new Bitmap(filePath);
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Jpeg);
                    customer.Picture = ms.ToArray();
                }

                connection.Insert(customer);
            }

            ReadDatabase();
            MessageBox.Show("顧客を登録しました。", "登録完了", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            //ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = null;
                CustomerListView.ItemsSource = _customers;
            }
        }


        //Listの名前を検索
        private void SerchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        //ListViewに入力されているデータを選択して削除
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する項目が選択されていません", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
            }

            ReadDatabase();
        }

        //ListViewに保存されている値を更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                // 値を更新
                item.Name = NameTextBox.Text;
                item.Phone = PhoneTextBox.Text;
                item.Address = AddressTextBox.Text;

                // 画像を更新
                if (!string.IsNullOrEmpty(filePath)) {
                    Bitmap bmp = new Bitmap(filePath);
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Jpeg);
                    item.Picture = ms.ToArray(); // 更新された画像
                }

                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(item);
                }

                ReadDatabase(); 
            } else {
                MessageBox.Show("更新する顧客を選択してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        //ListViewの値を選択するとテキストボックスに値を表示
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;

                if (item.Picture != null) {
                    PreviewImage.Source = Create(item.Picture);
                } else {
                    PreviewImage.Source = null;

                }
            }
        }

        public static BitmapImage Create(byte[] bytes) {
            var result = new BitmapImage();

            using (var stream = new MemoryStream(bytes)) {
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.CreateOptions = BitmapCreateOptions.None;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();    // 非UIスレッドから作成する場合、Freezeしないとメモリリークするため注意
            }

            return result;
        }

        //画像を選択して表示
        private void ImagePathButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true) {
                filePath = openFileDialog.FileName;

                Bitmap bmp = new Bitmap(filePath);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                picture = ms.ToArray(); // pictureを更新

                // プレビュー画像を表示
                PreviewImage.Source = new BitmapImage(new Uri(filePath));
            }
        }

        //入力されている値をクリアするボタン
        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();

        }

        //画像をクリアするボタン
        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            PreviewImage.Source = null;
            picture = null;
            var item = CustomerListView.SelectedItem as Customer;
            if (item != null) {
                item.Picture = null;
            }
        }

    }
}