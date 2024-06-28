using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport> ();   

        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Auther = cbAuther.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                
            };
            listCarReports.Add(carReport);

        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) { return CarReport.MakerGroup.トヨタ; }
            else if (rbNissan.Checked) { return CarReport.MakerGroup.日産; }
            else if (rbSubaru.Checked) { return CarReport.MakerGroup.スバル; }
            else if (rbHonda.Checked) { return CarReport.MakerGroup.ホンダ;}
            else if (rbImport.Checked) { return CarReport.MakerGroup.輸入車 ; }
            else return CarReport.MakerGroup.その他;
        }
    }
}
