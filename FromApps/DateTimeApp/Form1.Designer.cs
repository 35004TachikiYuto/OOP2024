namespace DateTimeApp {
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
            label1 = new Label();
            dtpBirthday = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btDayBefore = new Button();
            dayAfter = new Button();
            btYearOld = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F);
            label1.Location = new Point(67, 46);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Font = new Font("Yu Gothic UI", 12F);
            dtpBirthday.Location = new Point(183, 49);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(200, 29);
            dtpBirthday.TabIndex = 1;
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(267, 94);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(116, 49);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += button1_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Microsoft Sans Serif", 16F);
            tbDisp.Location = new Point(67, 267);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(316, 32);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 22F);
            nudDay.Location = new Point(67, 197);
            nudDay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 47);
            nudDay.TabIndex = 4;
            // 
            // btDayBefore
            // 
            btDayBefore.Font = new Font("Yu Gothic UI", 18F);
            btDayBefore.Location = new Point(267, 149);
            btDayBefore.Name = "btDayBefore";
            btDayBefore.Size = new Size(116, 47);
            btDayBefore.TabIndex = 5;
            btDayBefore.Text = "日前";
            btDayBefore.UseVisualStyleBackColor = true;
            btDayBefore.Click += btDayBefore_Click;
            // 
            // dayAfter
            // 
            dayAfter.Font = new Font("Yu Gothic UI", 18F);
            dayAfter.Location = new Point(267, 197);
            dayAfter.Name = "dayAfter";
            dayAfter.Size = new Size(116, 47);
            dayAfter.TabIndex = 5;
            dayAfter.Text = "日後";
            dayAfter.UseVisualStyleBackColor = true;
            dayAfter.Click += dayAfter_Click;
            // 
            // btYearOld
            // 
            btYearOld.Font = new Font("Yu Gothic UI", 18F);
            btYearOld.Location = new Point(389, 197);
            btYearOld.Name = "btYearOld";
            btYearOld.Size = new Size(116, 47);
            btYearOld.TabIndex = 6;
            btYearOld.Text = "年齢";
            btYearOld.UseVisualStyleBackColor = true;
            btYearOld.Click += btYearOld_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btYearOld);
            Controls.Add(dayAfter);
            Controls.Add(btDayBefore);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(dtpBirthday);
            Controls.Add(label1);
            Name = "Form1";
            Text = "生年月日";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpBirthday;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btDayBefore;
        private Button dayAfter;
        private Button btYearOld;
    }
}
