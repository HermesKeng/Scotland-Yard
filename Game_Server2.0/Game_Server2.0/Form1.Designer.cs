namespace Game_Server2._0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.infobox = new System.Windows.Forms.RichTextBox();
            this.start = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infobox
            // 
            this.infobox.Location = new System.Drawing.Point(12, 12);
            this.infobox.Name = "infobox";
            this.infobox.ReadOnly = true;
            this.infobox.Size = new System.Drawing.Size(546, 610);
            this.infobox.TabIndex = 0;
            this.infobox.Text = "";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(577, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(337, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(714, 83);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(75, 23);
            this.restart.TabIndex = 2;
            this.restart.Text = "restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Visible = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 634);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.start);
            this.Controls.Add(this.infobox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox infobox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button restart;

    }
}

