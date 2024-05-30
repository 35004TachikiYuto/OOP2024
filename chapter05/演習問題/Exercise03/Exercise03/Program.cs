using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
            int Count = text.Where(s => s == ' ').Count();
            Console.WriteLine("空白の数"+Count);
        }

        private static void Exercise3_2(string text) {
            string s =  text.Replace("big", "small");
            Console.WriteLine(s);
        }

        private static void Exercise3_3(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine("単語の数"+words.Length);
        }

        private static void Exercise3_4(string text) {
            string[] words = text.Split(' ');
            foreach(var s in words) {
                if (s.Count() <= 4)
                    Console.WriteLine(s);
            }
        }

        private static void Exercise3_5(string text) {
            string[] words = text.Split(' ');
            foreach (var s in words) {
                StringBuilder sb = new StringBuilder();
                sb.Append(s+' ');
                Console.Write(sb.ToString());
            }
        }

    }
}
