﻿namespace Exercise01 {
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
            btEx8_1 = new Button();
            tbDisp = new TextBox();
            btEx8_2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btEx8_1
            // 
            btEx8_1.Location = new Point(65, 42);
            btEx8_1.Name = "btEx8_1";
            btEx8_1.Size = new Size(131, 42);
            btEx8_1.TabIndex = 0;
            btEx8_1.Text = "問題8.1";
            btEx8_1.UseVisualStyleBackColor = true;
            btEx8_1.Click += btEx8_1_Click;
            // 
            // tbDisp
            // 
            tbDisp.Location = new Point(65, 192);
            tbDisp.Multiline = true;
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(554, 246);
            tbDisp.TabIndex = 1;
            // 
            // btEx8_2
            // 
            btEx8_2.Location = new Point(65, 90);
            btEx8_2.Name = "btEx8_2";
            btEx8_2.Size = new Size(131, 42);
            btEx8_2.TabIndex = 2;
            btEx8_2.Text = "問題8.2";
            btEx8_2.UseVisualStyleBackColor = true;
            btEx8_2.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(65, 138);
            button1.Name = "button1";
            button1.Size = new Size(131, 42);
            button1.TabIndex = 3;
            button1.Text = "問題8.3";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btEx8_2);
            Controls.Add(tbDisp);
            Controls.Add(btEx8_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btEx8_1;
        private TextBox tbDisp;
        private Button btEx8_2;
        private Button button1;
    }
}
