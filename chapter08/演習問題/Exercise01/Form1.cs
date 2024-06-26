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
            var str = now.ToString("ggyy�N M��d��(dddd)", culture);

            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy�NMM��dd�� HH��mm��ss�b") + "\r\n" +
                          str;
        }
        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        //�������Ŏw�肵�����t�̗��T�̃C���X�^���X��ԋp����B�������A�������Ŏw��
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var day = (int)dayOfWeek - (int)date.DayOfWeek;
            return nextweek.AddDays(day);


        }
        private void button1_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {

                //���T�̓��t���擾�i�߂�l���󂯎�邱�Ɓj

                var str1 = string.Format("{0:yy/MM/dd}�̎��T��{1}:", today, (DayOfWeek)dayofweek);
                var str2 = string.Format("{0:yy/MM/dd(ddd)}", NextWeek(today, (DayOfWeek)dayofweek));
                tbDisp.Text += str1 + str2 + "\r\n";

            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = string.Format("�������Ԃ�{0}�~���b�ł����B", duration.TotalNanoseconds);
            tbDisp.Text = str;        
        }
    }

    class TimeWatch {
        private DateTime _time;
        public void Start() {
            _time = DateTime.Now;

        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }
    }
}
