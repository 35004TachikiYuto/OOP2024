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

            var customer = new Customer();
            customer.Name = NameTextBox.Text;
            customer.Phone = PhoneTextBox.Text;
            customer.Address = AddressTextBox.Text;

            Bitmap bmp = new Bitmap(filePath);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            byte[] binaryData = ms.ToArray();
            customer.Picture = picture;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }

            ReadDatabase();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            //ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

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
                MessageBox.Show("削除する行が選択されていません", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
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
                // 既存のデータを更新
                item.Name = NameTextBox.Text;
                item.Phone = PhoneTextBox.Text;
                item.Address = AddressTextBox.Text;

                // 新しい画像が選択されていれば、それを使う
                if (item.Picture != null) {
                    PreviewImage.Source = Create(item.Picture);
                } else {
                    PreviewImage.Source = null;

                }
                // 画像が選択されていない場合は、既存の画像パスを保持

                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(item);
                }

                ReadDatabase();
            } else {
                MessageBox.Show("更新する人を選択してください", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
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
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp" // 画像ファイル
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true) {
                filePath = openFileDialog.FileName;
                // 画像ファイルを byte[] に変換
                picture = File.ReadAllBytes(filePath);

                // 画像をプレビューに表示
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