using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //�J�[���|�[�g�Ǘ��p���X�g
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
                // MessageBox.Show("�L�^�ҁA�Ԗ�����͂��Ȃ���", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tslbMessage.Text = "�L�^�ҁA�Ԗ�����͂��Ȃ���";
            }

        }

        

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setcbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }

        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        //�I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.�g���^;
            else if (rbNissan.Checked)
                return CarReport.MakerGroup.���Y;
            else if (rbSubaru.Checked)
                return CarReport.MakerGroup.�X�o��;
            else if (rbHonda.Checked)
                return CarReport.MakerGroup.�z���_;
            else if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;

            else return CarReport.MakerGroup.���̑�;
        }

        //�w�肵�����W�I�{�^���̃��[�J�[���Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbHonda.Checked = true;
                    break;
                default:
                    break;
            }
        }

        //�摜�I��
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //�摜�폜�{�^��
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        //�N���b�N�Ő؂�ւ�
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

        //�폜�{�^��
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {
                listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
                tslbMessage.Text = "";
            } else {
                tslbMessage.Text = "�폜����f�[�^������܂���";
            }
        }

        //�C���{�^��
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow != null) {
                CarReport selectedReport = listCarReports[dgvCarReport.CurrentRow.Index];

                selectedReport.Date = dtpDate.Value;
                selectedReport.Author = cbAuthor.Text;
                selectedReport.Maker = GetRadioButtonMaker();
                selectedReport.CarName = cbCarName.Text;
                selectedReport.Report = tbReport.Text;
                selectedReport.Picture = pbPicture.Image;

                dgvCarReport.Refresh();//�f�[�^�O���b�h�r���[�̍X�V

                tslbMessage.Text = "";

            } else {
                tslbMessage.Text = "�C������f�[�^������܂���";
            }
        }

    }
}
