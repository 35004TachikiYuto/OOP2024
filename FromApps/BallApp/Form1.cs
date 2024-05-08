namespace BallApp {
    public partial class Form1 : Form {

        Obj obj;
        PictureBox pb;

        //コンストラクタ
        public Form1() {
            InitializeComponent();

        }

        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {

            
                obj.Move();
                pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
           

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {

            pb = new PictureBox();//画像を表示するコントロール

            if (e.Button == MouseButtons.Left) {
                obj = new SoccerBall(e.X, e.Y);
                pb.Size = new Size(50, 50);
                pb.Image = obj.Image;
                pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;

                timer1.Start();
                

            } else if (e.Button == MouseButtons.Right) {
                obj = new TennisBall(e.X, e.Y);
                pb.Size = new Size(25, 25);
                pb.Image = obj.Image;
                pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;

                timer1.Start();
            }
        }
    }
}
