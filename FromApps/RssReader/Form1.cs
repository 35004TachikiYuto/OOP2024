using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {

    public partial class Form1 : Form {
        List<ItemData> items;
        Dictionary<string, string> dic;
        Dictionary<string, string> favoriteUrls;

        // お気に入りのタイトルを管理するリスト
        List<string> favoriteTitles;

        // URLを保存するフィールド
        private string currentUrl;

        public Form1() {
            InitializeComponent();
            dic = new Dictionary<string, string>() {
                {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
                {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
                {"国際","https://news.yahoo.co.jp/rss/topics/world.xml"},
                {"経済","https://news.yahoo.co.jp/rss/topics/business.xml"},
                {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
                {"スポーツ","https://news.yahoo.co.jp/rss/topics/sports.xml"},
                {"IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
                {"科学","https://news.yahoo.co.jp/rss/topics/science.xml"},
                {"地域","https://news.yahoo.co.jp/rss/topics/local.xml"}
            };
            cbRssUrl.Items.AddRange(dic.Keys.ToArray());
            cbRssUrl.SelectedIndexChanged += CbRssUrl_SelectedIndexChanged;
            btGet.Enabled = false; // 初期状態でボタンを無効にする

            // お気に入りのリストを初期化
            favoriteTitles = new List<string>();
            favoriteUrls = new Dictionary<string, string>();

            InitializeAsync();
            ShowInitialMessage();

            // 削除ボタンのイベントハンドラを追加
            btRemoveFavorite.Click += btRemoveFavorite_Click;
        }

        async void InitializeAsync() {
            await wv2.EnsureCoreWebView2Async(null);
        }

        private void ShowInitialMessage() {
            // フォームがロードされたときにメッセージボックスを表示
            var result = MessageBox.Show("項目を選択してからでないと取得ボタンは押せません！", "選択のお願い", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            // コンボボックスにアイテムが選択されているかどうかでボタンの有効/無効を切り替え
            btGet.Enabled = cbRssUrl.SelectedIndex >= 0;
        }

        private void btGet_Click(object sender, EventArgs e) {
            string url;
            if (dic.TryGetValue(cbRssUrl.Text, out url)) {
                // URLを保存
                currentUrl = url;

                using (var wc = new WebClient()) {
                    var rssUrl = wc.OpenRead(url);
                    var xdoc = XDocument.Load(rssUrl);

                    items = xdoc.Root.Descendants("item")
                        .Select(item => new ItemData {
                            Title = item.Element("title").Value,
                            Link = item.Element("link").Value
                        }).ToList();

                    lbRssTitle.Items.Clear();
                    foreach (var item in items) {
                        lbRssTitle.Items.Add("『" + item.Title + "』");
                    }
                }
            } else {
                MessageBox.Show("指定されたRSS URLが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != null) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                wv2.CoreWebView2.Navigate(selectedItem.Link);
            }


        }

        private void btFavorite_Click(object sender, EventArgs e) {
            var title = txtFavorite.Text.Trim();

            // テキストボックスが空でないか確認
            if (!string.IsNullOrEmpty(title)) {
                // 保存されたURLがあるか確認
                if (currentUrl != null) {
                    // お気に入りのタイトルとURLを辞書に追加
                    if (!favoriteTitles.Contains(title)) {
                        favoriteTitles.Add(title);
                        favoriteUrls[title] = currentUrl;
                        cbRssUrl.Items.Add(title);
                        MessageBox.Show($"URL: {currentUrl}", "お気に入り登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("このタイトルはすでにお気に入りに登録されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // テキストボックスをクリア
                    txtFavorite.Text = "";
                } else {
                    MessageBox.Show("まずは「取得」ボタンをクリックしてURLを取得してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("正しいタイトルを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemoveFavorite_Click(object sender, EventArgs e) {
            var selectedIndex = cbRssUrl.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < cbRssUrl.Items.Count) {
                var title = cbRssUrl.Items[selectedIndex].ToString();
                favoriteTitles.Remove(title);
                favoriteUrls.Remove(title);
                cbRssUrl.Items.RemoveAt(selectedIndex);

                // 選択を解除
                cbRssUrl.SelectedIndex = -1;
                btGet.Enabled = false;
            } else {
                MessageBox.Show("削除するアイテムを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }

}



