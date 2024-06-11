using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> name = new Dictionary<string, string>();
        static void Main(string[] args) {
            string name1,name2;

            //入力処理
            Console.WriteLine("県庁所在地の入力");

            while(true) { 
                //都道府県の入力
                Console.Write("都道府県:");
                name1 = Console.ReadLine();

                if(name1 == null) {
                    break;
                }

                //県庁所在地の入力
                Console.Write("県庁所在地:");
                name2 = Console.ReadLine();

                //すでに登録されているかどうか
                if (name.ContainsKey(name1)) {
                    Console.WriteLine("登録済みです。上書きしますか？？/Yes or No");
                    //登録済み

                    if (Console.ReadLine() == "No") {
                        continue;
                    }
                }
                name[name1] = name2;
            }
            Boolean endFlag = false;
            while (!endFlag) {
                switch (menuDisp()) {
                    case "1":
                        allDisp();
                        break;
                    case "2":
                        searchPrefCaptlLocation();
                        break;
                    case "9":
                        endFlag = true;//終了フラグON
                        break;
                }
            }
        }

        //メニュー表示
        private static string menuDisp() {
            Console.WriteLine("*メニュー*");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");
            Console.Write("入力:");
            string menu = Console.ReadLine();
            return menu;
        }

        private static void allDisp() {
            foreach (var ken in name) {
                Console.WriteLine("[{0}]の県庁所在地は[{1}]です", ken.Key, ken.Value);
            }
        }

        private static void searchPrefCaptlLocation() {
            Console.Write("都道府県:");
            var search = Console.ReadLine();
            if (name.ContainsKey(search)) {
                Console.WriteLine("県庁所在地:" + name[search]);
            } else {
                Console.WriteLine("登録されていません");
            }
        }
    }
}

