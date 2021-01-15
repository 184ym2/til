namespace GetFolder
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiパス入力 = new System.Windows.Forms.TextBox();
            this.uiフォルダ表示 = new System.Windows.Forms.ListBox();
            this.ui表示 = new System.Windows.Forms.Button();
            this.uiコピー = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiパス入力
            // 
            this.uiパス入力.Location = new System.Drawing.Point(10, 15);
            this.uiパス入力.Name = "uiパス入力";
            this.uiパス入力.Size = new System.Drawing.Size(262, 19);
            this.uiパス入力.TabIndex = 0;
            // 
            // uiフォルダ表示
            // 
            this.uiフォルダ表示.FormattingEnabled = true;
            this.uiフォルダ表示.HorizontalScrollbar = true;
            this.uiフォルダ表示.ItemHeight = 12;
            this.uiフォルダ表示.Location = new System.Drawing.Point(10, 43);
            this.uiフォルダ表示.Name = "uiフォルダ表示";
            this.uiフォルダ表示.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.uiフォルダ表示.Size = new System.Drawing.Size(682, 364);
            this.uiフォルダ表示.TabIndex = 1;
            // 
            // ui表示
            // 
            this.ui表示.Location = new System.Drawing.Point(278, 11);
            this.ui表示.Name = "ui表示";
            this.ui表示.Size = new System.Drawing.Size(74, 26);
            this.ui表示.TabIndex = 2;
            this.ui表示.Text = "取得開始";
            this.ui表示.UseVisualStyleBackColor = true;
            // 
            // uiコピー
            // 
            this.uiコピー.Location = new System.Drawing.Point(358, 11);
            this.uiコピー.Name = "uiコピー";
            this.uiコピー.Size = new System.Drawing.Size(74, 26);
            this.uiコピー.TabIndex = 3;
            this.uiコピー.Text = "コピー";
            this.uiコピー.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 427);
            this.Controls.Add(this.uiコピー);
            this.Controls.Add(this.ui表示);
            this.Controls.Add(this.uiフォルダ表示);
            this.Controls.Add(this.uiパス入力);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiパス入力;
        public System.Windows.Forms.ListBox uiフォルダ表示;
        private System.Windows.Forms.Button ui表示;
        private System.Windows.Forms.Button uiコピー;
    }
}

