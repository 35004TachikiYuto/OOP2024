using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {
        public int MainFormColor { get; set; }

        public Settings() {
            // デフォルトコンストラクタ
        }

        public Settings(Color backColor) {
            MainFormColor = backColor.ToArgb();
        }

        public Color GetBackColor() {
            return Color.FromArgb(MainFormColor);
        }
    }
}
