namespace BallApp {
    public partial class Form1 : Form {

        private double posX;    //X座標
        private double posY;    //Y座標
        private double moveX;   //移動量(x方向)
        private double moveY;   //移動量(y方向)

        //コンストラクタ
        public Form1() {
            InitializeComponent();

            moveX = moveY = 3;
        }

        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {
            this.BackColor = Color.Green;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //現在地を表示
            this.Text = pbBall.Location.ToString();

            if (pbBall.Location.X > 750|| pbBall.Location.X <0) {
                //移動量の符号を反転
                moveX = -moveX;
            }

            if (pbBall.Location.Y > 500|| pbBall.Location.Y<0) {
                //移動量の符号を反転
                moveY = -moveY;
            }

            posX += moveX;
            posY += moveY;

            pbBall.Location = new Point((int)posX, (int)posY);


        }
    }
}
