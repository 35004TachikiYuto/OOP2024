using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization.DataContracts;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンス作成
        Settings settings = Settings.getInstance();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
            
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text != "" || cbCarName.Text != "") {
                CarReport carReport = new CarReport {
                    Date = dtpDate.Value,
                    Author = cbAuthor.Text,
                    Maker = GetRadioButtonMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    Picture = pbPicture.Image,
                };

                listCarReports.Add(carReport);
                setcbAuthor(carReport.Author);
                setCbCarName(carReport.CarName);

                dgvCarReport.ClearSelection();//セレクションを外す
                inputItemsClear();

                tslbMessage.Text = "";
            } else {
                // MessageBox.Show("記録者、車名を入力しなさい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tslbMessage.Text = "記録者または車名が未入力です";

            }

        }

        private void inputItemsClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }



        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setcbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }

        }

        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            else if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            else if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            else if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            else if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;

            else return CarReport.MakerGroup.その他;
        }



        //指定したラジオボタンのメーカーをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {


            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbHonda.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbSubaru.Checked = false;
            rbHonda.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;


        }

        //画像選択
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //画像削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;

        }

        //
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;//画像表示しない

            //交互に色を設定（データグリッドビュー）
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //設定ファイルを逆シリアル化して背景を設定
            if (File.Exists("settings.xml")) {
                try {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "色情報ファイルが破損しています";
                }
            }else {
               tslbMessage.Text = "色情報ファイルがありません";
            }
        }

        //クリックで切り替え
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0) || (!dgvCarReport.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;


        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {

                listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
                dgvCarReport.ClearSelection();//セレクションを外す
                tslbMessage.Text = "";
            } else {
                tslbMessage.Text = "削除するデータがありません";
            }
        }

        //修正ボタン
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {
                CarReport selectedReport = listCarReports[dgvCarReport.CurrentRow.Index];

                selectedReport.Date = dtpDate.Value;
                selectedReport.Author = cbAuthor.Text;
                selectedReport.Maker = GetRadioButtonMaker();
                selectedReport.CarName = cbCarName.Text;
                selectedReport.Report = tbReport.Text;
                selectedReport.Picture = pbPicture.Image;

                dgvCarReport.Refresh();//データグリッドビューの更新

                tslbMessage.Text = "";

            } else {
                tslbMessage.Text = "修正するデータがありません";
            }
        }

        //記録者のテキストが編集されたら
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        //車名のテキストが編集されたら
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        //保存ボタンイベントハンドラ
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        //ファイルセーブ処理
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                        tslbMessage.Text = "";
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "書き込みエラー";
                }
            }
        }

        //開くボタンイベントハンドラ
        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        //ファイルオープン処理
        private void ReportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs
                        = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;
                        foreach (var cbBox in listCarReports) {
                            setcbAuthor(cbBox.Author);
                            setCbCarName(cbBox.CarName);
                            tslbMessage.Text = "";
                        }
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "ファイル形式が違います";
                }
                dgvCarReport.ClearSelection();//セレクションを外す
            }
        }

        //ファイル保存処理
        private void btClear_Click(object sender, EventArgs e) {
            inputItemsClear();//入力項目をすべてクリア
            dgvCarReport.ClearSelection();//セレクションを外す
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();//ファイルオープン処理
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();//ファイルセーブ処理
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("本当に終了しますか？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//終了するか確認

                Application.Exit();

        }

        //色設定処理
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (cdColor.ShowDialog() == DialogResult.OK)
                BackColor = cdColor.Color;
            settings.MainFormColor = cdColor.Color.ToArgb();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("設定ファイル書き込みエラー", "エラー");
            }
        }
    }
}
