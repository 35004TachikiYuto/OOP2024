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
            lbRssTitle.SelectedIndexChanged += lbRssTitle_SelectedIndexChanged; // イベントハンドラーの紐付け
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
            var message = "項目を選択してからでないと取得ボタンは押せません！\nお気に入り登録は項目を選択してからしてください！";
            MessageBox.Show(message, "諸注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            // コンボボックスにアイテムが選択されているかどうかでボタンの有効/無効を切り替え
            btGet.Enabled = cbRssUrl.SelectedIndex >= 0;
        }

        private void btGet_Click(object sender, EventArgs e) {
            string url;

            // コンボボックスで選択されているアイテムがあるか確認
            if (cbRssUrl.SelectedIndex >= 0) {
                var selectedTitle = cbRssUrl.Text;

                // お気に入りが選択されている場合
                if (favoriteUrls.TryGetValue(selectedTitle, out url)) {
                    currentUrl = url; // お気に入りのURLを保存
                }
                // 通常のRSS URLの場合
                else if (dic.TryGetValue(selectedTitle, out url)) {
                    currentUrl = url; // 通常のRSS URLを保存
                } else {
                    MessageBox.Show("指定されたRSS URLが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadRssFromUrl(currentUrl); // URLからRSSを取得
            } else {
                MessageBox.Show("項目を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            // リストボックスの選択インデックスの確認
            if (lbRssTitle.SelectedIndex >= 0 && lbRssTitle.SelectedIndex < items.Count) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                if (selectedItem != null && !string.IsNullOrEmpty(selectedItem.Link)) {
                    try {
                        // WebView2のCoreWebView2が初期化されているかチェック
                        if (wv2.CoreWebView2 != null) {
                            // 選択されたリンク先にナビゲート
                            wv2.CoreWebView2.Navigate(selectedItem.Link);
                        } else {
                            MessageBox.Show("WebView2が初期化されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"ページの表示に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("選択された項目のリンクが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("無効な項目が選択されました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRssFromUrl(string url) {
            try {
                using (var wc = new WebClient()) {
                    var rssUrl = wc.OpenRead(url);
                    var xdoc = XDocument.Load(rssUrl);

                    items = xdoc.Root.Descendants("item")
                        .Select(item => new ItemData {
                            Title = item.Element("title")?.Value,
                            Link = item.Element("link")?.Value
                        }).ToList();

                    lbRssTitle.Items.Clear();
                    foreach (var item in items) {
                        lbRssTitle.Items.Add("『" + item.Title + "』");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFavorite_Click(object sender, EventArgs e) {
            var title = txtFavorite.Text.Trim();

            if (!string.IsNullOrEmpty(title)) {
                if (currentUrl != null) {
                    if (!favoriteTitles.Contains(title)) {
                        favoriteTitles.Add(title);
                        favoriteUrls[title] = currentUrl; // ここでURLを保存
                        cbRssUrl.Items.Add(title);

                        // メッセージを「登録完了」に変更
                        MessageBox.Show("登録完了", "お気に入り登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("このタイトルはすでにお気に入りに登録されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    txtFavorite.Text = "";
                } else {
                    MessageBox.Show("まずは「取得」ボタンをクリックしてURLを取得してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("正しいタイトルを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemoveFavorite_Click(object sender, EventArgs e) {
            // コンボボックスで何も選択されていない場合のチェック
            if (cbRssUrl.SelectedIndex == -1) {
                // エラーメッセージを一度だけ表示する
                MessageBox.Show("削除するアイテムを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 処理を終了
            }

            // 選択されている項目の取得
            var title = cbRssUrl.SelectedItem.ToString();

            // お気に入りのリストから削除処理
            if (favoriteTitles.Contains(title) && favoriteUrls.ContainsKey(title)) {
                // 削除処理
                favoriteTitles.Remove(title);
                favoriteUrls.Remove(title);
                cbRssUrl.Items.RemoveAt(cbRssUrl.SelectedIndex);

                // 削除成功メッセージを表示
                MessageBox.Show("削除が成功しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 削除後の選択を行う
                if (cbRssUrl.Items.Count > 0) {
                    // 他にアイテムがあれば、最初のアイテムを選択
                    cbRssUrl.SelectedIndex = 0;
                } else {
                    // アイテムがなくなった場合は選択解除
                    cbRssUrl.SelectedIndex = -1;
                    btGet.Enabled = false; // ボタンを無効にする
                }
            }
        }




    }
    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }

}



