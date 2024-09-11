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

        // お気に入りのタイトルを管理するリスト
        List<string> favoriteTitles;

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
            var result = MessageBox.Show("項目を選択しないと取得ボタンは押せません", "選択のお願い", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

            private void CbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            // コンボボックスにアイテムが選択されているかどうかでボタンの有効/無効を切り替え
            btGet.Enabled = cbRssUrl.SelectedIndex >= 0;
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {

                var url = wc.OpenRead(dic[cbRssUrl.Text]);
                var xdoc = XDocument.Load(url);

                items = xdoc.Root.Descendants("item")
                                            .Select(item => new ItemData {
                                                Title = item.Element("title").Value,
                                                Link = item.Element("link").Value
                                            }).ToList();

                lbRssTitle.Items.Clear();
                foreach (var titles in items) {
                    lbRssTitle.Items.Add("『" + titles.Title + "』");

                }

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
            if (!string.IsNullOrEmpty(title) && !favoriteTitles.Contains(title)) {
                // お気に入りのタイトルをリストに追加
                favoriteTitles.Add(title);
                cbRssUrl.Items.Add(title);

                // テキストボックスをクリア
                txtFavorite.Text = "";
            } else {
                MessageBox.Show("正しく入力してください。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btRemoveFavorite_Click(object sender, EventArgs e) {
            // お気に入りのリストから選択されたアイテムを削除
            var selectedIndex = cbRssUrl.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < favoriteTitles.Count) {
                // 選択されたタイトルをリストから削除
                favoriteTitles.RemoveAt(selectedIndex);

                // コンボボックスからも削除
                cbRssUrl.Items.RemoveAt(selectedIndex);

                // 選択を解除
                cbRssUrl.SelectedIndex = -1;
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



