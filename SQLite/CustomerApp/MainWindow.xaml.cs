﻿using CustomerApp.Objects;
using SQLite;
using System;
using System.Collections.Generic;
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
        private string imagePath;
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        //値を入植してSave
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = imagePath,
            };
            
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
            ClearTextBox();
        }

        private void ClearTextBox() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
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

        private void SerchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        //ListViewに入力されているデータを選択して削除
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
            }
            ReadDatabase();
            ClearTextBox();
        }

        //ListViewに保存されている値を更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                item.Name = NameTextBox.Text;
                item.Phone = PhoneTextBox.Text;
                item.Address = AddressTextBox.Text;


                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(item);
                }
                ReadDatabase();
                ClearTextBox();
            } else {
                MessageBox.Show("更新する顧客を選択してください", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //ListViewの値を選択するとテキストボックスに値を表示
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;
            }
        }

        //画像を選択して表示
        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp" // 画像ファイルのフィルタ
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true) {
                string imagePath = openFileDialog.FileName;

                PreviewImage.Source = new BitmapImage(new Uri(imagePath));

                var customer = new Customer {
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text,
                };

                SaveCustomer(customer);
            }
        }

        private void SaveCustomer(Customer customer) {
            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Insert(customer);
                }

                ReadDatabase();
                ClearTextBox();
            }
            catch (Exception ex) {
                MessageBox.Show("保存中にエラーが発生しました: " + ex.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

