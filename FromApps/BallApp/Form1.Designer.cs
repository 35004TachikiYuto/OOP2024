namespace BallApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            pbBall = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbBall).BeginInit();
            SuspendLayout();
            // 
            // pbBall
            // 
            pbBall.Image = Properties.Resources.soccer_ball;
            pbBall.Location = new Point(0, 0);
            pbBall.Name = "pbBall";
            pbBall.Size = new Size(50, 50);
            pbBall.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBall.TabIndex = 0;
            pbBall.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(784, 561);
            Controls.Add(pbBall);
            Name = "Form1";
            Text = "BallApp";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbBall).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbBall;
        private System.Windows.Forms.Timer timer1;
    }
}
