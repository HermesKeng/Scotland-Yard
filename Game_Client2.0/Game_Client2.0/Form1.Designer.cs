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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(813, 69);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(157, 30);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(813, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "192.168.100.6";
            // 
            // infobox
            // 
            this.infobox.Location = new System.Drawing.Point(775, 105);
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
            this.player.Location = new System.Drawing.Point(781, 17);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(0, 40);
            this.player.TabIndex = 3;
            this.player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player.Visible = false;
            // 
            // move
            // 
            this.move.Location = new System.Drawing.Point(974, 76);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(75, 23);
            this.move.TabIndex = 4;
            this.move.Text = "move";
            this.move.UseVisualStyleBackColor = true;
            this.move.Visible = false;
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Game_Client2._0.Properties.Resources.sample_map1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel1.Location = new System.Drawing.Point(72, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 485);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(265, 376);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(42, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(473, 433);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(42, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "button4";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(459, 355);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "button4";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(310, 442);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(358, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(310, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(393, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(788, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 590);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.move);
            this.Controls.Add(this.player);
            this.Controls.Add(this.infobox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.RichTextBox infobox;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

