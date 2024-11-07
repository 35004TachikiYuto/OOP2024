﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    //メートル単位を表すクラス
    public class GramUnit : WeightUnit {
        private static List<GramUnit> units = new List<GramUnit>() {
            new GramUnit{ Name = "g",Coefficient = 1,},
            new GramUnit{ Name = "kg",Coefficient = 1000,},
            new GramUnit{ Name = "t",Coefficient = 1000000,},

        };
        public static ICollection<GramUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド単位からグラム単位に変換します
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 28.34952 / this.Coefficient;
        }
    }
}
