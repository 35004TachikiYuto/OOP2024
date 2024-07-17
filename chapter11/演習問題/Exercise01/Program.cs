using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sample = xdoc.Root.Elements()
                                    .Select(x => new {
                                        Name = (string)x.Element("name"),
                                        Teammembers = (int)x.Element("teammembers"),
                                    });
            foreach (var xsample in sample) {
                Console.WriteLine("{0},{1}",xsample.Name,xsample.Teammembers);
            }
           
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sample = xdoc.Root.Elements().OrderBy(x => (int)x.Element("firstplayed"));

            foreach (var xsample in sample){
                var xname = xsample.Element("name");
                XAttribute xkanji = xname.Attribute("kanji");
                Console.WriteLine(xkanji?.Value);
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var sample = xdoc.Root.Elements("ballsport");
            var max = sample.OrderByDescending(x=>(int)x.Element("teammembers"))
                .FirstOrDefault();
            var xname = max.Element("name");

            
            Console.WriteLine(xname.Value);

        }

        private static void Exercise1_4(string file, string newfile) {
        }
    }
}
