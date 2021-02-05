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
            this.ui検索文字列入力 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiパス入力
            // 
            this.uiパス入力.Location = new System.Drawing.Point(92, 23);
            this.uiパス入力.Name = "uiパス入力";
            this.uiパス入力.Size = new System.Drawing.Size(224, 22);
            this.uiパス入力.TabIndex = 1;
            this.uiパス入力.Text = "C:\\UR\\";
            // 
            // uiフォルダ表示
            // 
            this.uiフォルダ表示.FormattingEnabled = true;
            this.uiフォルダ表示.HorizontalScrollbar = true;
            this.uiフォルダ表示.ItemHeight = 14;
            this.uiフォルダ表示.Location = new System.Drawing.Point(12, 97);
            this.uiフォルダ表示.Name = "uiフォルダ表示";
            this.uiフォルダ表示.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.uiフォルダ表示.Size = new System.Drawing.Size(795, 382);
            this.uiフォルダ表示.TabIndex = 4;
            // 
            // ui表示
            // 
            this.ui表示.Location = new System.Drawing.Point(324, 23);
            this.ui表示.Name = "ui表示";
            this.ui表示.Size = new System.Drawing.Size(75, 51);
            this.ui表示.TabIndex = 3;
            this.ui表示.Text = "取得開始";
            this.ui表示.UseVisualStyleBackColor = true;
            // 
            // uiコピー
            // 
            this.uiコピー.Location = new System.Drawing.Point(404, 23);
            this.uiコピー.Name = "uiコピー";
            this.uiコピー.Size = new System.Drawing.Size(75, 51);
            this.uiコピー.TabIndex = 5;
            this.uiコピー.Text = "コピー";
            this.uiコピー.UseVisualStyleBackColor = true;
            // 
            // ui検索文字列入力
            // 
            this.ui検索文字列入力.Location = new System.Drawing.Point(92, 52);
            this.ui検索文字列入力.Name = "ui検索文字列入力";
            this.ui検索文字列入力.Size = new System.Drawing.Size(224, 22);
            this.ui検索文字列入力.TabIndex = 2;
            this.ui検索文字列入力.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "検索文字列";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(485, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 84);
            this.label3.TabIndex = 7;
            this.label3.Text = "---?：任意の一文字を意味します---\r\n「200?年」→「2001年」「200a年」などにヒット\r\n---*：任意の文字列を意味します　0文字にもヒットします" +
    "---\r\n「2*年」→「2年」「234年」「2abc年」などにヒット\r\n「*.txt」→「abc.txt」「1234.txt」などにヒット\r\n「*.*」→「ab" +
    "c.jpg」「1234.xml」などにヒット";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ui検索文字列入力);
            this.Controls.Add(this.uiコピー);
            this.Controls.Add(this.ui表示);
            this.Controls.Add(this.uiフォルダ表示);
            this.Controls.Add(this.uiパス入力);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.TextBox ui検索文字列入力;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

