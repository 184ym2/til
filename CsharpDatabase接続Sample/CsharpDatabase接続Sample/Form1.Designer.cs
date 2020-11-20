namespace CsharpDatabase接続Sample
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui複数表示 = new System.Windows.Forms.Button();
            this.ui単一値表示 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiIP = new System.Windows.Forms.TextBox();
            this.uiスキーマ名 = new System.Windows.Forms.TextBox();
            this.uiパネル = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.uiIPアドレス手入力 = new System.Windows.Forms.CheckBox();
            this.uitestlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.uiパネル.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 126);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(419, 185);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(11, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 23);
            this.label1.TabIndex = 1;
            // 
            // ui複数表示
            // 
            this.ui複数表示.Font = new System.Drawing.Font("IPAゴシック", 10F);
            this.ui複数表示.Location = new System.Drawing.Point(274, 76);
            this.ui複数表示.Name = "ui複数表示";
            this.ui複数表示.Size = new System.Drawing.Size(75, 44);
            this.ui複数表示.TabIndex = 2;
            this.ui複数表示.Text = "複数表示";
            this.ui複数表示.UseVisualStyleBackColor = true;
            this.ui複数表示.Click += new System.EventHandler(this.複数_Click);
            // 
            // ui単一値表示
            // 
            this.ui単一値表示.Font = new System.Drawing.Font("IPAゴシック", 10F);
            this.ui単一値表示.Location = new System.Drawing.Point(355, 76);
            this.ui単一値表示.Name = "ui単一値表示";
            this.ui単一値表示.Size = new System.Drawing.Size(75, 44);
            this.ui単一値表示.TabIndex = 3;
            this.ui単一値表示.Text = "単一値\r\n表示";
            this.ui単一値表示.UseVisualStyleBackColor = true;
            this.ui単一値表示.Click += new System.EventHandler(this.単一_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 318);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(419, 185);
            this.dataGridView1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "IPアドレス";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "スキーマ名";
            // 
            // uiIP
            // 
            this.uiIP.Location = new System.Drawing.Point(87, 9);
            this.uiIP.Name = "uiIP";
            this.uiIP.Size = new System.Drawing.Size(147, 20);
            this.uiIP.TabIndex = 7;
            this.uiIP.Text = ".\\SQLEXPRESS";
            // 
            // uiスキーマ名
            // 
            this.uiスキーマ名.Location = new System.Drawing.Point(87, 37);
            this.uiスキーマ名.Name = "uiスキーマ名";
            this.uiスキーマ名.Size = new System.Drawing.Size(147, 20);
            this.uiスキーマ名.TabIndex = 8;
            this.uiスキーマ名.Text = "AdventureWorks2017";
            // 
            // uiパネル
            // 
            this.uiパネル.Controls.Add(this.uiスキーマ名);
            this.uiパネル.Controls.Add(this.uiIP);
            this.uiパネル.Controls.Add(this.label6);
            this.uiパネル.Controls.Add(this.label5);
            this.uiパネル.Enabled = false;
            this.uiパネル.Location = new System.Drawing.Point(12, 54);
            this.uiパネル.Name = "uiパネル";
            this.uiパネル.Size = new System.Drawing.Size(249, 66);
            this.uiパネル.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "＊ Connect to the database ＊";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiIPアドレス手入力
            // 
            this.uiIPアドレス手入力.AutoSize = true;
            this.uiIPアドレス手入力.Location = new System.Drawing.Point(13, 33);
            this.uiIPアドレス手入力.Name = "uiIPアドレス手入力";
            this.uiIPアドレス手入力.Size = new System.Drawing.Size(158, 17);
            this.uiIPアドレス手入力.TabIndex = 11;
            this.uiIPアドレス手入力.Text = "IPアドレスを手入力する";
            this.uiIPアドレス手入力.UseVisualStyleBackColor = true;
            this.uiIPアドレス手入力.CheckedChanged += new System.EventHandler(this.uiIPアドレス手入力_CheckedChanged);
            // 
            // uitestlabel
            // 
            this.uitestlabel.AutoSize = true;
            this.uitestlabel.Location = new System.Drawing.Point(271, 54);
            this.uitestlabel.Name = "uitestlabel";
            this.uitestlabel.Size = new System.Drawing.Size(43, 13);
            this.uitestlabel.TabIndex = 12;
            this.uitestlabel.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 538);
            this.Controls.Add(this.uitestlabel);
            this.Controls.Add(this.uiIPアドレス手入力);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiパネル);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ui単一値表示);
            this.Controls.Add(this.ui複数表示);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("IPAゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.uiパネル.ResumeLayout(false);
            this.uiパネル.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ui複数表示;
        private System.Windows.Forms.Button ui単一値表示;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiIP;
        private System.Windows.Forms.TextBox uiスキーマ名;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox uiIPアドレス手入力;
        public System.Windows.Forms.Panel uiパネル;
        private System.Windows.Forms.Label uitestlabel;
    }
}

