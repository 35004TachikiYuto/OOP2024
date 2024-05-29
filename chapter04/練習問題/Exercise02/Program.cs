using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            // 4.2.1
            var ymCollection = new YearMonth[] {
                 new YearMonth(1980, 1),
                 new YearMonth(1990, 4),
                 new YearMonth(2000, 7),
                 new YearMonth(2000, 9),
                 new YearMonth(2000, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }
        //4.2.3(4.2.4で呼び出されるメソッド)
        static YearMonth FindFrist21c(YearMonth[] yms) {
            foreach (var ym in yms) {
                if (ym.Is21Century) {
                    return ym;
                }
            }
            return null;
        }
        private static void Exercise2_4(YearMonth[] ymCollection) {
            /*var ym = FindFrist21c(ymCollection);
            if (ym == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(ym);
            }*/
            var ym = FindFrist21c(ymCollection);

            Console.WriteLine(ym == null ? "21世紀のデータはありません" : ym.ToString());
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            /*var ym = new YearMonth[ymCollection.Length];
            for (int i = 0; i < ymCollection.Length; i++) {
                ym[i] = ymCollection[i].AddOneMonth();
            }*/
            var array = ymCollection.Select(ym=> ym.AddOneMonth()).ToArray();
            foreach (var yms in array) {
                Console.WriteLine(yms);
            }
        }
    }
}
