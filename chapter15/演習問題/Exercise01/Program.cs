using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(b => b.Price);

            var book = Library.Books.First(b => b.Price == max);

            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var group = Library.Books.GroupBy(b => b.PublishedYear)
                                    .Select(g => new { PublishedYear = g.Key, Count = g.Count() })
                                    .OrderBy(y => y.PublishedYear);

            foreach (var book in group) {
                Console.WriteLine("{0}年 {1}冊", book.PublishedYear, book.Count);
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books.OrderByDescending(b => b.PublishedYear)
                                    .ThenByDescending(b => b.Price)
                                    .Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => new {
                                            PublishedYear = book.PublishedYear,
                                            Price = book.Price,
                                            Title = book.Title,
                                            Category = category.Name,
                                        }
                                    );

            foreach (var book in books) {
                Console.WriteLine("{0}年 {1}円 {2} ({3})",
                                book.PublishedYear,
                                book.Price,
                                book.Title,
                                book.Category);
            }
        }

        private static void Exercise1_5() {
            var quary = Library.Books
                            .Where(b => b.PublishedYear == 2016)
                            .Join(Library.Categories,            // 結合する二番目のシーケンス
                                        book => book.CategoryId, //対象シーケンスの結合キー
                                        category => category.Id, //2番目シーケンスの結合キー
                                        (book, category) => category.Name)
                                        .Distinct();

            foreach (var name in quary) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {

            //模範解答
            var quary = Library.Books
                            .Join(Library.Categories,            // 結合する二番目のシーケンス
                                        book => book.CategoryId, //対象シーケンスの結合キー
                                        category => category.Id, //2番目シーケンスの結合キー
                                        (book, category) => new {
                                            book.Title,
                                            CategoryName = category.Name,
                                        })
                            .GroupBy(x => x.CategoryName)
                            .OrderBy(x => x.Key);

            foreach (var group in quary) {
                Console.WriteLine("#{0}", group.Key);
                foreach (var books in group) {
                    Console.WriteLine("  {0}", books.Title);
                }
            }

            //自分のやつ
            /*var groups = Library.Categories.OrderBy(b => b.Name)
                                         .GroupJoin(Library.Books,
                                             c => c.Id,
                                             b => b.CategoryId,
                                             (c, books) => new {
                                                 Category = c.Name,
                                                 Title = books.GroupBy(t => t.Title),
                                                 Books = books
                                             });
            foreach (var group in groups) {
                Console.WriteLine($"#{group.Category}");
                foreach (var books in group.Books) {
                    Console.WriteLine($"  {books.Title}");
                }
            }*/

        }

        private static void Exercise1_7() {
            var categorysId = Library.Categories.Single(b => b.Name == "Development").Id;
            var quary = Library.Books.Where(b => b.CategoryId == categorysId)
                                        .GroupBy(b => b.PublishedYear)
                                        .OrderBy(b => b.Key);
            foreach (var years in quary) {
                Console.WriteLine("#{0}年", years.Key);
                foreach (var titles in years) {
                    Console.WriteLine("  {0}", titles.Title);
                }
            }
        }

        private static void Exercise1_8() {
            //模範解答
            var quary = Library.Categories
                                .GroupJoin(Library.Books,
                                            c => c.Id,
                                            b => b.CategoryId,
                                            (c, b) => new {
                                                CategoryName = c.Name,
                                                Count = b.Count()
                                            })
                                .Where(x => x.Count >= 4);
            foreach (var group in quary) {
                Console.WriteLine(group.CategoryName + "(" + group.Count + "冊)")
            }

            /*var quary = Library.Categories
                            .GroupJoin(Library.Books,
                                c => c.Id,
                                b => b.CategoryId,
                                (c, books) => new {
                                    Category = c.Name,
                                    Count = books.Count(),
                                }).Where(x => x.Count >= 4);
            foreach (var books in quary) {
                Console.WriteLine("{0}", books.Category);
            }*/


        }
    }
}
