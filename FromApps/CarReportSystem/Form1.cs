using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

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
                
                

                tslbMessage.Text = "";
            } else {
                // MessageBox.Show("記録者、車名を入力しなさい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tslbMessage.Text = "記録者、車名を入力しなさい";
            }

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
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        //クリックで切り替え
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {
                dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
                setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
                tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
                pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;

            }
        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {
                listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
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

    }
}
