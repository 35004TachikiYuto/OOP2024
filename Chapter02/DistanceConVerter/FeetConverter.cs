using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConVerter {
    public class FeetConverter {

        //rivate const double raito = 0.3048;//定数
        public static readonly double raito = 0.3048; //定数（外部にも公開する場合）

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / raito;
        }
        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * raito;
        }
    }
}
