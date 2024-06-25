using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var now = DateTime.Now;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = now.ToString("ggyy”N MŒŽd“ú(dddd)", culture);

            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy”NMMŒŽdd“ú HHŽžmm•ªss•b") + "\r\n" +
                          str;
        }
        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        private void button1_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            DateTime nextSunday = NextDay(today, DayOfWeek.Sunday);
            tbDisp.Text = nextSunday.ToString("ŽŸ‚Ì“ú—j“ú‚Í" + "MMŒŽdd“ú");
        }
    }
}
