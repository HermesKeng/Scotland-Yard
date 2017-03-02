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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Login = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.GameEnd = new System.Windows.Forms.Panel();
            this.ResultPic = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Result_Text = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Left_Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Right_Panel = new System.Windows.Forms.Panel();
            this.Move_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Ticket = new System.Windows.Forms.RichTextBox();
            this.Input_Panel = new System.Windows.Forms.Panel();
            this.TransportPic = new System.Windows.Forms.PictureBox();
            this.move = new System.Windows.Forms.Button();
            this.Transport = new System.Windows.Forms.ListBox();
            this.Input_TextBox = new System.Windows.Forms.TextBox();
            this.RecordBox = new System.Windows.Forms.Panel();
            this.RecordBox_Title = new System.Windows.Forms.Label();
            this.infobox = new System.Windows.Forms.RichTextBox();
            this.FudenmentalInfo = new System.Windows.Forms.Panel();
            this.Player_Text = new System.Windows.Forms.Label();
            this.Player_Image = new System.Windows.Forms.PictureBox();
            this.game_panel = new System.Windows.Forms.Panel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.GameEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Left_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Right_Panel.SuspendLayout();
            this.Move_Panel.SuspendLayout();
            this.Input_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransportPic)).BeginInit();
            this.RecordBox.SuspendLayout();
            this.FudenmentalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Image)).BeginInit();
            this.game_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Login.Controls.Add(this.pictureBox2);
            this.Login.Controls.Add(this.label1);
            this.Login.Controls.Add(this.textBox1);
            this.Login.Controls.Add(this.start_btn);
            this.Login.Location = new System.Drawing.Point(0, 0);
            this.Login.Margin = new System.Windows.Forms.Padding(0);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Login.Size = new System.Drawing.Size(334, 225);
            this.Login.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(309, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(57, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "請輸入IP位置：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(184, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 29);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "192.168.100.6";
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.start_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.start_btn.Location = new System.Drawing.Point(57, 159);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(237, 38);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // GameEnd
            // 
            this.GameEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.GameEnd.Controls.Add(this.ResultPic);
            this.GameEnd.Controls.Add(this.label2);
            this.GameEnd.Controls.Add(this.Result_Text);
            this.GameEnd.Controls.Add(this.Close);
            this.GameEnd.Controls.Add(this.pictureBox3);
            this.GameEnd.Location = new System.Drawing.Point(0, 0);
            this.GameEnd.Margin = new System.Windows.Forms.Padding(0);
            this.GameEnd.Name = "GameEnd";
            this.GameEnd.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.GameEnd.Size = new System.Drawing.Size(334, 225);
            this.GameEnd.TabIndex = 6;
            this.GameEnd.Visible = false;
            // 
            // ResultPic
            // 
            this.ResultPic.Location = new System.Drawing.Point(16, 53);
            this.ResultPic.Name = "ResultPic";
            this.ResultPic.Size = new System.Drawing.Size(194, 100);
            this.ResultPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResultPic.TabIndex = 21;
            this.ResultPic.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(233, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "獲勝！";
            // 
            // Result_Text
            // 
            this.Result_Text.AutoSize = true;
            this.Result_Text.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Result_Text.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Result_Text.Location = new System.Drawing.Point(111, 12);
            this.Result_Text.Name = "Result_Text";
            this.Result_Text.Size = new System.Drawing.Size(110, 31);
            this.Result_Text.TabIndex = 19;
            this.Result_Text.Text = "遊戲結果";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Close.Location = new System.Drawing.Point(216, 159);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(100, 51);
            this.Close.TabIndex = 18;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 159);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(194, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // Left_Panel
            // 
            this.Left_Panel.AutoScroll = true;
            this.Left_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Left_Panel.Controls.Add(this.pictureBox1);
            this.Left_Panel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Left_Panel.Location = new System.Drawing.Point(3, 3);
            this.Left_Panel.Name = "Left_Panel";
            this.Left_Panel.Size = new System.Drawing.Size(922, 635);
            this.Left_Panel.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1460, 1125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Right_Panel
            // 
            this.Right_Panel.Controls.Add(this.Move_Panel);
            this.Right_Panel.Controls.Add(this.RecordBox);
            this.Right_Panel.Controls.Add(this.FudenmentalInfo);
            this.Right_Panel.Location = new System.Drawing.Point(925, 3);
            this.Right_Panel.Name = "Right_Panel";
            this.Right_Panel.Size = new System.Drawing.Size(320, 632);
            this.Right_Panel.TabIndex = 23;
            // 
            // Move_Panel
            // 
            this.Move_Panel.Controls.Add(this.label3);
            this.Move_Panel.Controls.Add(this.Ticket);
            this.Move_Panel.Controls.Add(this.Input_Panel);
            this.Move_Panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Move_Panel.Location = new System.Drawing.Point(3, 186);
            this.Move_Panel.Name = "Move_Panel";
            this.Move_Panel.Size = new System.Drawing.Size(309, 136);
            this.Move_Panel.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "車票資訊";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ticket
            // 
            this.Ticket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Ticket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ticket.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Ticket.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Ticket.Location = new System.Drawing.Point(3, 23);
            this.Ticket.Name = "Ticket";
            this.Ticket.ReadOnly = true;
            this.Ticket.Size = new System.Drawing.Size(106, 108);
            this.Ticket.TabIndex = 15;
            this.Ticket.Text = "";
            // 
            // Input_Panel
            // 
            this.Input_Panel.Controls.Add(this.TransportPic);
            this.Input_Panel.Controls.Add(this.move);
            this.Input_Panel.Controls.Add(this.Transport);
            this.Input_Panel.Controls.Add(this.Input_TextBox);
            this.Input_Panel.Location = new System.Drawing.Point(115, 3);
            this.Input_Panel.Name = "Input_Panel";
            this.Input_Panel.Padding = new System.Windows.Forms.Padding(3);
            this.Input_Panel.Size = new System.Drawing.Size(213, 139);
            this.Input_Panel.TabIndex = 17;
            this.Input_Panel.Visible = false;
            // 
            // TransportPic
            // 
            this.TransportPic.Image = global::Game_Client2._0.Properties.Resources.defaultTic;
            this.TransportPic.Location = new System.Drawing.Point(79, 8);
            this.TransportPic.Name = "TransportPic";
            this.TransportPic.Size = new System.Drawing.Size(128, 50);
            this.TransportPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TransportPic.TabIndex = 11;
            this.TransportPic.TabStop = false;
            // 
            // move
            // 
            this.move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.move.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(153)))), ((int)(((byte)(53)))));
            this.move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.move.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.move.Location = new System.Drawing.Point(88, 95);
            this.move.Margin = new System.Windows.Forms.Padding(5);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(110, 36);
            this.move.TabIndex = 4;
            this.move.Text = "Move";
            this.move.UseVisualStyleBackColor = false;
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // Transport
            // 
            this.Transport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Transport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Transport.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Transport.FormattingEnabled = true;
            this.Transport.ItemHeight = 20;
            this.Transport.Items.AddRange(new object[] {
            "計程車",
            "公車",
            "地鐵"});
            this.Transport.Location = new System.Drawing.Point(6, 8);
            this.Transport.Name = "Transport";
            this.Transport.Size = new System.Drawing.Size(66, 120);
            this.Transport.TabIndex = 10;
            this.Transport.SelectedIndexChanged += new System.EventHandler(this.Transport_SelectedIndexChanged);
            // 
            // Input_TextBox
            // 
            this.Input_TextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Input_TextBox.Location = new System.Drawing.Point(88, 64);
            this.Input_TextBox.Name = "Input_TextBox";
            this.Input_TextBox.Size = new System.Drawing.Size(110, 29);
            this.Input_TextBox.TabIndex = 6;
            // 
            // RecordBox
            // 
            this.RecordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordBox.Controls.Add(this.RecordBox_Title);
            this.RecordBox.Controls.Add(this.infobox);
            this.RecordBox.Location = new System.Drawing.Point(3, 325);
            this.RecordBox.Name = "RecordBox";
            this.RecordBox.Padding = new System.Windows.Forms.Padding(3);
            this.RecordBox.Size = new System.Drawing.Size(314, 312);
            this.RecordBox.TabIndex = 24;
            // 
            // RecordBox_Title
            // 
            this.RecordBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordBox_Title.AutoSize = true;
            this.RecordBox_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordBox_Title.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RecordBox_Title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RecordBox_Title.Location = new System.Drawing.Point(80, 6);
            this.RecordBox_Title.Name = "RecordBox_Title";
            this.RecordBox_Title.Size = new System.Drawing.Size(134, 31);
            this.RecordBox_Title.TabIndex = 3;
            this.RecordBox_Title.Text = "遊戲記錄表";
            this.RecordBox_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infobox
            // 
            this.infobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.infobox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.infobox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infobox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infobox.Location = new System.Drawing.Point(3, 45);
            this.infobox.Name = "infobox";
            this.infobox.ReadOnly = true;
            this.infobox.Size = new System.Drawing.Size(308, 264);
            this.infobox.TabIndex = 2;
            this.infobox.Text = "";
            // 
            // FudenmentalInfo
            // 
            this.FudenmentalInfo.Controls.Add(this.Player_Text);
            this.FudenmentalInfo.Controls.Add(this.Player_Image);
            this.FudenmentalInfo.Location = new System.Drawing.Point(3, 3);
            this.FudenmentalInfo.Name = "FudenmentalInfo";
            this.FudenmentalInfo.Size = new System.Drawing.Size(325, 61);
            this.FudenmentalInfo.TabIndex = 23;
            // 
            // Player_Text
            // 
            this.Player_Text.AutoSize = true;
            this.Player_Text.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Player_Text.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Player_Text.Location = new System.Drawing.Point(87, 12);
            this.Player_Text.Name = "Player_Text";
            this.Player_Text.Size = new System.Drawing.Size(0, 40);
            this.Player_Text.TabIndex = 17;
            this.Player_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player_Image
            // 
            this.Player_Image.Location = new System.Drawing.Point(8, 6);
            this.Player_Image.Name = "Player_Image";
            this.Player_Image.Size = new System.Drawing.Size(72, 50);
            this.Player_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player_Image.TabIndex = 0;
            this.Player_Image.TabStop = false;
            // 
            // game_panel
            // 
            this.game_panel.BackColor = System.Drawing.Color.Transparent;
            this.game_panel.Controls.Add(this.Right_Panel);
            this.game_panel.Controls.Add(this.Left_Panel);
            this.game_panel.Location = new System.Drawing.Point(0, 0);
            this.game_panel.Margin = new System.Windows.Forms.Padding(0);
            this.game_panel.Name = "game_panel";
            this.game_panel.Padding = new System.Windows.Forms.Padding(3);
            this.game_panel.Size = new System.Drawing.Size(1243, 641);
            this.game_panel.TabIndex = 8;
            this.game_panel.Visible = false;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1245, 641);
            this.Controls.Add(this.game_panel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.GameEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEP工人訓-蘇格蘭特警";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.GameEnd.ResumeLayout(false);
            this.GameEnd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.Left_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Right_Panel.ResumeLayout(false);
            this.Move_Panel.ResumeLayout(false);
            this.Move_Panel.PerformLayout();
            this.Input_Panel.ResumeLayout(false);
            this.Input_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransportPic)).EndInit();
            this.RecordBox.ResumeLayout(false);
            this.RecordBox.PerformLayout();
            this.FudenmentalInfo.ResumeLayout(false);
            this.FudenmentalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Image)).EndInit();
            this.game_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Panel Login;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel GameEnd;
        private System.Windows.Forms.PictureBox ResultPic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Result_Text;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel Left_Panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Right_Panel;
        private System.Windows.Forms.FlowLayoutPanel Move_Panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox Ticket;
        private System.Windows.Forms.Panel Input_Panel;
        private System.Windows.Forms.PictureBox TransportPic;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.ListBox Transport;
        private System.Windows.Forms.TextBox Input_TextBox;
        private System.Windows.Forms.Panel RecordBox;
        private System.Windows.Forms.Label RecordBox_Title;
        public System.Windows.Forms.RichTextBox infobox;
        private System.Windows.Forms.Panel FudenmentalInfo;
        private System.Windows.Forms.Label Player_Text;
        private System.Windows.Forms.PictureBox Player_Image;
        private System.Windows.Forms.Panel game_panel;
    }
}

