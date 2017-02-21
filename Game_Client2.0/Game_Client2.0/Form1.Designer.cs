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
            this.components = new System.ComponentModel.Container();
            this.start_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.infobox = new System.Windows.Forms.RichTextBox();
            this.player = new System.Windows.Forms.Label();
            this.move = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ticket = new System.Windows.Forms.Label();
            this.restart = new System.Windows.Forms.Button();
            this.round = new System.Windows.Forms.Label();
            this.Transport = new System.Windows.Forms.ListBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(638, 60);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(157, 30);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(659, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "192.168.100.3";
            // 
            // infobox
            // 
            this.infobox.Location = new System.Drawing.Point(623, 134);
            this.infobox.Name = "infobox";
            this.infobox.ReadOnly = true;
            this.infobox.Size = new System.Drawing.Size(172, 262);
            this.infobox.TabIndex = 2;
            this.infobox.Text = "";
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.player.Location = new System.Drawing.Point(637, 462);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(0, 40);
            this.player.TabIndex = 3;
            this.player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player.Visible = false;
            // 
            // move
            // 
            this.move.Location = new System.Drawing.Point(306, 297);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(75, 50);
            this.move.TabIndex = 4;
            this.move.Text = "move";
            this.move.UseVisualStyleBackColor = true;
            this.move.Visible = false;
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(306, 351);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // ticket
            // 
            this.ticket.AutoSize = true;
            this.ticket.Location = new System.Drawing.Point(530, 421);
            this.ticket.Name = "ticket";
            this.ticket.Size = new System.Drawing.Size(0, 12);
            this.ticket.TabIndex = 7;
            // 
            // restart
            // 
            this.restart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.restart.Location = new System.Drawing.Point(305, 324);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(75, 23);
            this.restart.TabIndex = 8;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Visible = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // round
            // 
            this.round.AutoSize = true;
            this.round.Location = new System.Drawing.Point(636, 91);
            this.round.Name = "round";
            this.round.Size = new System.Drawing.Size(0, 12);
            this.round.TabIndex = 9;
            // 
            // Transport
            // 
            this.Transport.FormattingEnabled = true;
            this.Transport.ItemHeight = 12;
            this.Transport.Items.AddRange(new object[] {
            "計程車",
            "公車",
            "地鐵"});
            this.Transport.Location = new System.Drawing.Point(227, 297);
            this.Transport.Name = "Transport";
            this.Transport.Size = new System.Drawing.Size(66, 76);
            this.Transport.TabIndex = 10;
            this.Transport.Visible = false;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Game_Client2._0.Client);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Game_Client2._0.Form1);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(858, 577);
            this.Controls.Add(this.Transport);
            this.Controls.Add(this.round);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.ticket);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.move);
            this.Controls.Add(this.player);
            this.Controls.Add(this.infobox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.RichTextBox infobox;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label ticket;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Label round;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ListBox Transport;
    }
}

