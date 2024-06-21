using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("生年月日を入力");
            Console.Write("年：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());

            var Birthday = new DateTime(year, month, day);

            //DayOfWeek dayOfWeek = Birthday.DayOfWeek;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str =Birthday.ToString("ggyy年M月d日dddd",culture);
            
            //あなたは平成〇〇年〇月〇日〇曜日に生まれました。
            Console.WriteLine("貴方は" +str+"に生まれました。");

            //あなたは生まれてから今日で○○○○日メデス
            var today = DateTime.Today;
            TimeSpan diff = Birthday - today;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です。",diff.Days);
            /*switch (dayOfWeek) {
                case DayOfWeek.Monday:
                    Console.WriteLine("あなたは月曜日に生まれました。");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("あなたは火曜日に生まれました。");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("あなたは水曜日に生まれました。");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("あなたは木曜日に生まれました。");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("あなたは金曜日に生まれました。");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("あなたは土曜日に生まれました。");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("あなたは日曜日に生まれました。");
                    break;
                default:
                    Console.WriteLine("曜日の取得に失敗しました。");
                    break;
            }*/

        }
    }
}
