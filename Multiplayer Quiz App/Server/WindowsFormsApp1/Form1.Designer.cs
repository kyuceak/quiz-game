namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionNumberBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelConnectedCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelInGameCount = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(142, 40);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(182, 20);
            this.textBox_port.TabIndex = 0;
            this.textBox_port.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(328, 39);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(56, 19);
            this.button_listen.TabIndex = 3;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(86, 92);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(361, 196);
            this.logs.TabIndex = 4;
            this.logs.Text = "";
            this.logs.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 314);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Questions:";
            // 
            // QuestionNumberBox
            // 
            this.QuestionNumberBox.Location = new System.Drawing.Point(204, 312);
            this.QuestionNumberBox.Margin = new System.Windows.Forms.Padding(2);
            this.QuestionNumberBox.Name = "QuestionNumberBox";
            this.QuestionNumberBox.Size = new System.Drawing.Size(104, 20);
            this.QuestionNumberBox.TabIndex = 6;
            this.QuestionNumberBox.TextChanged += new System.EventHandler(this.QuestionNumberBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(463, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connected";
            // 
            // labelConnectedCount
            // 
            this.labelConnectedCount.AutoSize = true;
            this.labelConnectedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectedCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelConnectedCount.Location = new System.Drawing.Point(496, 114);
            this.labelConnectedCount.Name = "labelConnectedCount";
            this.labelConnectedCount.Size = new System.Drawing.Size(19, 20);
            this.labelConnectedCount.TabIndex = 8;
            this.labelConnectedCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(463, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "In Game";
            // 
            // labelInGameCount
            // 
            this.labelInGameCount.AutoSize = true;
            this.labelInGameCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInGameCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelInGameCount.Location = new System.Drawing.Point(496, 190);
            this.labelInGameCount.Name = "labelInGameCount";
            this.labelInGameCount.Size = new System.Drawing.Size(19, 20);
            this.labelInGameCount.TabIndex = 10;
            this.labelInGameCount.Text = "0";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(467, 226);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 366);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelInGameCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelConnectedCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuestionNumberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox QuestionNumberBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelConnectedCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelInGameCount;
        private System.Windows.Forms.Button buttonStart;
    }
}

