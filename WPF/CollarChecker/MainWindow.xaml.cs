using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CollarChecker {
    public partial class MainWindow : Window {

        MyColor currentColor;//現在設定している色情報

        public MainWindow() {
            InitializeComponent();
            //αチャンネルの初期値を設定(起動時すぐにストックボタンが押された場合の対応)
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);

            DataContext = GetColorList();
        }

        //スライドを動かすと呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            /*var rValue = (byte)rSlider.Value;
            var gValue = (byte)gSlider.Value;
            var bValue = (byte)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(rValue, gValue, bValue));*/

            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            currentColor.Name = GetColorList().Where(x => x.Color.Equals(currentColor.Color)).Select(c=>c.Name).FirstOrDefault();
            colorArea.Background = new SolidColorBrush(currentColor.Color);
            StockButton.Background = new SolidColorBrush(currentColor.Color);


        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            /*byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            MyColor myColor = new MyColor() {
                Color = Color.FromRgb(r, g, b),
                Name = $"R:{r}, G:{g}, B:{b}"
            };
            StockList.Items.Add(myColor); */// MyColorオブジェクトをListBoxに追加

            if (!StockList.Items.Contains((MyColor)currentColor)) {
                StockList.Items.Insert(0, currentColor);

            } else {
                MessageBox.Show("登録済みの値です。","ColorChecker",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }


        private void StockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            //colorArea.Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            //setSliderValue(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);

            if (StockList.SelectedIndex != -1) { 
                var selectedColor = (MyColor)StockList.SelectedItem;
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                setSliderValue(selectedColor.Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }



        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea.Background = new SolidColorBrush(((MyColor)ColorSelectComboBox.Items[ColorSelectComboBox.SelectedIndex]).Color);
            setSliderValue(((MyColor)ColorSelectComboBox.Items[ColorSelectComboBox.SelectedIndex]).Color);
            var tempCurrntColor = (MyColor)((ComboBox)sender).SelectedItem;
            //各スライダーの値を設定する
            setSliderValue(currentColor.Color);
            currentColor.Name = tempCurrntColor.Name;//Nameプロパティの文字列を再設定
            
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            // ストックリストが空か確認
            if (StockList.Items.Count == 0) {
                MessageBox.Show("ストックにデータがありません。", "ColorChecker", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 選択されている項目があるか確認
            if (StockList.SelectedItem == null) {
                MessageBox.Show("削除するアイテムを選択してください。", "ColorChecker", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 確認メッセージを表示
            var result = MessageBox.Show("本当に削除しますか？", "ColorChecker", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // ユーザーが「はい」を選択した場合
            if (result == MessageBoxResult.Yes) {
                StockList.Items.Remove(StockList.SelectedItem);
            }
        }
    }
}