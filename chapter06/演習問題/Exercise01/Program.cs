using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine("最大値：" + max);
        }

        private static void Exercise1_2(int[] numbers) {
            var skip = numbers.Length - 2;
            foreach (var number in numbers.Skip(skip))
                Console.WriteLine(number);
        }

        private static void Exercise1_3(int[] numbers) {
            var strings = numbers.Select(n => n.ToString("0000"));
            foreach (var numStrings in strings) {
                Console.WriteLine(numStrings);
            }
        }

        private static void Exercise1_4(int[] numbers) {
            foreach (var number in numbers.OrderBy(n => n).Take(3))
                Console.WriteLine(number);
        }

        private static void Exercise1_5(int[] numbers) {
            var count = numbers.Distinct().Count(n => n > 10);

            Console.WriteLine(count);


        }
    }

}
