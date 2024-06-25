namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

            //tbDisp.Text = "››“ú–Ú";
            var today = DateTime.Today;
            TimeSpan diff = today - dtpBirthday.Value;
            tbDisp.Text = diff.Days + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            var past = dtpBirthday.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = past.ToString("d");
        }

        private void dayAfter_Click(object sender, EventArgs e) {
            var past = dtpBirthday.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = past.ToString("d");
        }

        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age).AddDays(-1)) {
                age--;
            }
            return age;
        }


        private void btYearOld_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            int age = GetAge(dtpBirthday.Value, today);
            tbDisp.Text = age.ToString("d") + "Ë";


        }
    }
}
