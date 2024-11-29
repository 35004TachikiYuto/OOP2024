using SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace CustomerApp.Objects {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 画像 (バイナリデータ)
        /// </summary>
        public byte[] Picture { get; set; }

        public override string ToString() {
            return $"{Id}  {Name}  {Phone}   {Address}";
        }

        [Ignore] // SQLiteに保存しないプロパティ
        public BitmapImage ImagePath => Picture != null ? ConvertToBitmapImage(Picture) : null;

        private BitmapImage ConvertToBitmapImage(byte[] bytes) {
            using (var stream = new MemoryStream(bytes)) {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
}
