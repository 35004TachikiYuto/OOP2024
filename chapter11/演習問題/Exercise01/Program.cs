﻿using System;
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
                                        Name = x.Element("name"),
                                        Teammembers = x.Element("teammembers"),
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
            var max = xdoc.Root.Elements()
                        .OrderByDescending(x=>x.Element("teammembers").Value)
                        .First();
            

            
            Console.WriteLine($"{max.Element("name").Value}");

        }

        private static void Exercise1_4(string file, string newfile) {

            List<XElement> xElments = new List<XElement>();

            var xdoc = XDocument.Load(file);

            string name, kanji,tm,fp;
            int nextFlag;
            while (true) {
                Console.Write("名称:");
                name = Console.ReadLine();
                Console.Write("漢字:");
                kanji = Console.ReadLine();
                Console.Write("人数:");
                tm = (Console.ReadLine());
                Console.Write("起源");
                fp = (Console.ReadLine());

                var element = new XElement("ballsport",
                              new XElement("name", name, new XAttribute("kanji", kanji)),
                              new XElement("teammembers", tm),
                              new XElement("firstplayed", fp)
                );
                xElments.Add(element);//リストへ要素を追加

                Console.WriteLine();//改行

                Console.Write("追加【1】 保存【2】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2) break;//無限ループを抜ける
                Console.WriteLine();//改行
            }
            xdoc.Root.Add(xElments);
            xdoc.Save("BallSports.xml");
        }
    }
}
