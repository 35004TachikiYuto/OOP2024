namespace RssReader {
    partial class Form1 {
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
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.cbRssUrl = new System.Windows.Forms.ComboBox();
            this.wv2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtFavorite = new System.Windows.Forms.TextBox();
            this.btFavorite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btRemoveFavorite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wv2)).BeginInit();
            this.SuspendLayout();
            // 
            // btGet
            // 
            this.btGet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btGet.Location = new System.Drawing.Point(673, 3);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(75, 31);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = false;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(12, 101);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(251, 520);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // cbRssUrl
            // 
            this.cbRssUrl.FormattingEnabled = true;
            this.cbRssUrl.Location = new System.Drawing.Point(207, 9);
            this.cbRssUrl.Name = "cbRssUrl";
            this.cbRssUrl.Size = new System.Drawing.Size(460, 20);
            this.cbRssUrl.TabIndex = 4;
            // 
            // wv2
            // 
            this.wv2.AllowExternalDrop = true;
            this.wv2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.wv2.CreationProperties = null;
            this.wv2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wv2.Location = new System.Drawing.Point(274, 101);
            this.wv2.Name = "wv2";
            this.wv2.Size = new System.Drawing.Size(514, 520);
            this.wv2.TabIndex = 5;
            this.wv2.ZoomFactor = 1D;
            // 
            // txtFavorite
            // 
            this.txtFavorite.Location = new System.Drawing.Point(207, 48);
            this.txtFavorite.Name = "txtFavorite";
            this.txtFavorite.Size = new System.Drawing.Size(282, 19);
            this.txtFavorite.TabIndex = 8;
            // 
            // btFavorite
            // 
            this.btFavorite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btFavorite.Location = new System.Drawing.Point(509, 40);
            this.btFavorite.Name = "btFavorite";
            this.btFavorite.Size = new System.Drawing.Size(77, 34);
            this.btFavorite.TabIndex = 9;
            this.btFavorite.Text = "登録";
            this.btFavorite.UseVisualStyleBackColor = false;
            this.btFavorite.Click += new System.EventHandler(this.btFavorite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ 明朝", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(45, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "URL又はお気に入り名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ＭＳ 明朝", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(45, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "お気に入り名称：";
            // 
            // btRemoveFavorite
            // 
            this.btRemoveFavorite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btRemoveFavorite.Location = new System.Drawing.Point(606, 40);
            this.btRemoveFavorite.Name = "btRemoveFavorite";
            this.btRemoveFavorite.Size = new System.Drawing.Size(77, 34);
            this.btRemoveFavorite.TabIndex = 12;
            this.btRemoveFavorite.Text = "削除";
            this.btRemoveFavorite.UseVisualStyleBackColor = false;
            this.btRemoveFavorite.Click += new System.EventHandler(this.btRemoveFavorite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 626);
            this.Controls.Add(this.btRemoveFavorite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btFavorite);
            this.Controls.Add(this.txtFavorite);
            this.Controls.Add(this.wv2);
            this.Controls.Add(this.cbRssUrl);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.ComboBox cbRssUrl;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv2;
        private System.Windows.Forms.TextBox txtFavorite;
        private System.Windows.Forms.Button btFavorite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRemoveFavorite;
    }
}

