namespace projectclient
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.IPText = new System.Windows.Forms.Label();
            this.PortText = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.AnswerText = new System.Windows.Forms.Label();
            this.AnswerBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(126, 38);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(213, 22);
            this.IPBox.TabIndex = 0;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(126, 97);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(213, 22);
            this.PortBox.TabIndex = 1;
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(126, 168);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(213, 22);
            this.NameBox.TabIndex = 2;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // IPText
            // 
            this.IPText.AutoSize = true;
            this.IPText.Location = new System.Drawing.Point(77, 41);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(22, 16);
            this.IPText.TabIndex = 3;
            this.IPText.Text = "IP:";
            this.IPText.Click += new System.EventHandler(this.label1_Click);
            // 
            // PortText
            // 
            this.PortText.AutoSize = true;
            this.PortText.Location = new System.Drawing.Point(65, 100);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(34, 16);
            this.PortText.TabIndex = 4;
            this.PortText.Text = "Port:";
            this.PortText.Click += new System.EventHandler(this.PortText_Click);
            // 
            // NameText
            // 
            this.NameText.AutoSize = true;
            this.NameText.Location = new System.Drawing.Point(65, 171);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(47, 16);
            this.NameText.TabIndex = 5;
            this.NameText.Text = "Name:";
            this.NameText.Click += new System.EventHandler(this.NameText_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(126, 340);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(92, 32);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(247, 340);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(92, 32);
            this.DisconnectButton.TabIndex = 7;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // RichTextBox
            // 
            this.RichTextBox.Location = new System.Drawing.Point(427, 38);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(274, 334);
            this.RichTextBox.TabIndex = 8;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // AnswerText
            // 
            this.AnswerText.AutoSize = true;
            this.AnswerText.Location = new System.Drawing.Point(398, 408);
            this.AnswerText.Name = "AnswerText";
            this.AnswerText.Size = new System.Drawing.Size(84, 16);
            this.AnswerText.TabIndex = 10;
            this.AnswerText.Text = "Your answer:";
            this.AnswerText.Click += new System.EventHandler(this.AnswerText_Click);
            // 
            // AnswerBox
            // 
            this.AnswerBox.Location = new System.Drawing.Point(488, 405);
            this.AnswerBox.Name = "AnswerBox";
            this.AnswerBox.Size = new System.Drawing.Size(213, 22);
            this.AnswerBox.TabIndex = 9;
            this.AnswerBox.TextChanged += new System.EventHandler(this.AnswerBox_TextChanged);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(707, 401);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(82, 25);
            this.SendButton.TabIndex = 11;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.AnswerText);
            this.Controls.Add(this.AnswerBox);
            this.Controls.Add(this.RichTextBox);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.IPText);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IPBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label IPText;
        private System.Windows.Forms.Label PortText;
        private System.Windows.Forms.Label NameText;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.RichTextBox RichTextBox;
        private System.Windows.Forms.Label AnswerText;
        private System.Windows.Forms.TextBox AnswerBox;
        private System.Windows.Forms.Button SendButton;
    }
}

