using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var books = Books.GetBooks().OrderByDescending(x => x.Price).ToList();

            books.ForEach(b => Console.WriteLine(b.Title + ":" + b.Price));

            /*foreach (var book in books) {
                Console.WriteLine(book.Title+":"+book.Price);
            }*/
        }
    }
}
