using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {

        class Book {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
        }


        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
};

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var book = books.Where(x => x.Title == "ワンダフル・C#ライフ");
            foreach (var b in book) {
                Console.WriteLine("{0}価格:{1} ページ数：{2}", b.Title, b.Price, b.Pages);
             }
        }

        private static void Exercise2_2(List<Book> books) {
            var book = books.Count(n => n.Title.Contains("C#"));
            Console.WriteLine(book);
        }

        private static void Exercise2_3(List<Book> books) {
            var book = books.Where(n => n.Title.Contains("C#")).ToArray();
            var avg = book.Average(b => b.Pages);
            Console.WriteLine(avg);
        }

        private static void Exercise2_4(List<Book> books) {
            var book = books.Where(n => n.Price >= 4000).FirstOrDefault();
            Console.WriteLine(book.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var book = books.Where(n => n.Price < 4000);
            var max = book.Max(b => b.Pages);
            Console.WriteLine("ページ数：" + max);
        }

        private static void Exercise2_6(List<Book> books) {
            var book = books.Where(n => n.Pages >= 400);
            var num = book.OrderByDescending(b => b.Price);
            foreach (var page in num) {
                Console.WriteLine("タイトル：{0} 価格：{1}", page.Title, page.Price);
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var book = books.Where(n => n.Title.Contains("C#")).Where(n => n.Pages <= 500);
            foreach (var b in book){
                Console.WriteLine("タイトル："+b.Title);
            }
        }
    }


}
