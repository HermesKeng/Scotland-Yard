namespace Game_Client2._0
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.start_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.infobox = new System.Windows.Forms.RichTextBox();
            this.player = new System.Windows.Forms.Label();
            this.move = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(584, 76);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(157, 30);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(574, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "192.168.100.6";
            // 
            // infobox
            // 
            this.infobox.Location = new System.Drawing.Point(536, 112);
            this.infobox.Name = "infobox";
            this.infobox.ReadOnly = true;
            this.infobox.Size = new System.Drawing.Size(237, 477);
            this.infobox.TabIndex = 2;
            this.infobox.Text = "";
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.player.Location = new System.Drawing.Point(542, 44);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(0, 40);
            this.player.TabIndex = 3;
            this.player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player.Visible = false;
            // 
            // move
            // 
            this.move.Location = new System.Drawing.Point(316, 129);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(75, 23);
            this.move.TabIndex = 4;
            this.move.Text = "move";
            this.move.UseVisualStyleBackColor = true;
            this.move.Visible = false;
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 613);
            this.Controls.Add(this.move);
            this.Controls.Add(this.player);
            this.Controls.Add(this.infobox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.RichTextBox infobox;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Button move;
    }
}

