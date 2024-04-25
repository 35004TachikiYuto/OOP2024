using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {

            var songs = new Song[] {

            new Song("Lemon","米津玄師",300),
            new Song("クリスマスソング","back number",330),
            new Song("キセキ","GreeeeN",360)
            };
            
            PrintSongs(songs);
        }

        //2.1.4
        private static void PrintSongs(Song[] songs) {

            Console.WriteLine(@"{0:hh\:mm\:ss}",TimeSpan.FromSeconds(153));
        }

    }
}
