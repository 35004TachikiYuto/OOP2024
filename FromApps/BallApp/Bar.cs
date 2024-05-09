using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class Bar : Obj {

        public Bar(double xp, double yp)
           : base(xp - 25, yp - 25, @"Picture\bar.png") {

            MoveX = 10;//移動量設定
            MoveY = 0;
        }

        public override bool Move() {
            return true;
        }

        public override bool Move(Keys direction) {
            if (PosX > 625 || PosX < 0) {
                //移動の符号を反転
                MoveX = -MoveX;
            }
            if (direction == Keys.Right) {
                if (PosX < 635) {
                    PosX += MoveX;
                }
            } else if (direction == Keys.Left) {
                if (PosX > 0) {
                    PosX -= MoveX;
                }
            }
            return true;
        }
    }
}
