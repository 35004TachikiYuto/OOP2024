namespace Section03 {
    partial class bt16_6 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt16_7 = new System.Windows.Forms.Button();
            this.bt16_8 = new System.Windows.Forms.Button();
            this.bt16_9 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "イベントハンドラを非同期にする(1)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // bt16_7
            // 
            this.bt16_7.Location = new System.Drawing.Point(12, 40);
            this.bt16_7.Name = "bt16_7";
            this.bt16_7.Size = new System.Drawing.Size(271, 23);
            this.bt16_7.TabIndex = 2;
            this.bt16_7.Text = "イベントハンドラを非同期にする(2)";
            this.bt16_7.UseVisualStyleBackColor = true;
            this.bt16_7.Click += new System.EventHandler(this.bt16_7_Click);
            // 
            // bt16_8
            // 
            this.bt16_8.Location = new System.Drawing.Point(12, 69);
            this.bt16_8.Name = "bt16_8";
            this.bt16_8.Size = new System.Drawing.Size(271, 23);
            this.bt16_8.TabIndex = 3;
            this.bt16_8.Text = "非同期メソッドの定義(戻り値のない場合)";
            this.bt16_8.UseVisualStyleBackColor = true;
            this.bt16_8.Click += new System.EventHandler(this.bt16_8_Click);
            // 
            // bt16_9
            // 
            this.bt16_9.Location = new System.Drawing.Point(12, 98);
            this.bt16_9.Name = "bt16_9";
            this.bt16_9.Size = new System.Drawing.Size(271, 23);
            this.bt16_9.TabIndex = 4;
            this.bt16_9.Text = "非同期メソッドの定義(戻り値のある場合)";
            this.bt16_9.UseVisualStyleBackColor = true;
            this.bt16_9.Click += new System.EventHandler(this.bt16_9_Click);
            // 
            // bt16_6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 262);
            this.Controls.Add(this.bt16_9);
            this.Controls.Add(this.bt16_8);
            this.Controls.Add(this.bt16_7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Name = "bt16_6";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button bt16_7;
        private System.Windows.Forms.Button bt16_8;
        private System.Windows.Forms.Button bt16_9;
    }
}

