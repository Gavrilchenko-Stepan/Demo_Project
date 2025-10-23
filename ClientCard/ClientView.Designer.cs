namespace ClientCard
{
    partial class ClientView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AvatarBox = new System.Windows.Forms.PictureBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.MailLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.Location = new System.Drawing.Point(20, 20);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(83, 32);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "label1";
            // 
            // AvatarBox
            // 
            this.AvatarBox.BackColor = System.Drawing.Color.White;
            this.AvatarBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvatarBox.Location = new System.Drawing.Point(250, 15);
            this.AvatarBox.Name = "AvatarBox";
            this.AvatarBox.Size = new System.Drawing.Size(180, 180);
            this.AvatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AvatarBox.TabIndex = 1;
            this.AvatarBox.TabStop = false;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.DescriptionLabel.Location = new System.Drawing.Point(22, 70);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(200, 80);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "label1";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.PhoneLabel.Location = new System.Drawing.Point(16, 10);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(40, 15);
            this.PhoneLabel.TabIndex = 3;
            this.PhoneLabel.Text = "label1";
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.MailLabel.Location = new System.Drawing.Point(16, 40);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(40, 15);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.PhoneLabel);
            this.panel1.Controls.Add(this.MailLabel);
            this.panel1.Location = new System.Drawing.Point(25, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 70);
            this.panel1.TabIndex = 5;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.AvatarBox);
            this.Controls.Add(this.TitleLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.Name = "ClientView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(448, 248);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientView_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ClientView_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ClientView_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox AvatarBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
