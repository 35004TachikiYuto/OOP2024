namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOk = new Button();
            label1 = new Label();
            lbVersion = new Label();
            lbCopyRight = new Label();
            lbAuthor = new Label();
            SuspendLayout();
            // 
            // btVersionOk
            // 
            btVersionOk.Location = new Point(278, 180);
            btVersionOk.Name = "btVersionOk";
            btVersionOk.Size = new Size(61, 26);
            btVersionOk.TabIndex = 0;
            btVersionOk.Text = "OK";
            btVersionOk.UseVisualStyleBackColor = true;
            btVersionOk.Click += btVersionOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("游ゴシック", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(21, 15);
            label1.Name = "label1";
            label1.Size = new Size(253, 31);
            label1.TabIndex = 1;
            label1.Text = "カーレポートシステム";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("メイリオ", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(33, 64);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(67, 20);
            lbVersion.TabIndex = 1;
            lbVersion.Text = "Ver.0.0.1";
            // 
            // lbCopyRight
            // 
            lbCopyRight.AutoSize = true;
            lbCopyRight.Location = new Point(33, 84);
            lbCopyRight.Name = "lbCopyRight";
            lbCopyRight.Size = new Size(38, 15);
            lbCopyRight.TabIndex = 2;
            lbCopyRight.Text = "label3";
            // 
            // lbAuthor
            // 
            lbAuthor.AutoSize = true;
            lbAuthor.Location = new Point(33, 99);
            lbAuthor.Name = "lbAuthor";
            lbAuthor.Size = new Size(38, 15);
            lbAuthor.TabIndex = 3;
            lbAuthor.Text = "label4";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 236);
            Controls.Add(lbAuthor);
            Controls.Add(lbCopyRight);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btVersionOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOk;
        private Label label1;
        private Label lbVersion;
        private Label lbCopyRight;
        private Label lbAuthor;
    }
}