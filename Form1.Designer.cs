using System.Drawing;
using System.Windows.Forms;

namespace NDP_Odev
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBox1;
        private Button btnPlay;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            btnPlay = new Button();
            lblTitle = new Label();
            btnSkor = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Comic Sans MS", 14.25F);
            textBox1.ForeColor = Color.Gray;
            textBox1.Location = new Point(233, 236);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Oyuncu Adı";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "Oyuncu Adı";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.DodgerBlue;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(270, 278);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(127, 36);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Oyna";
            btnPlay.UseMnemonic = false;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(243, 181);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(181, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sau Bonanza";
            // 
            // btnSkor
            // 
            btnSkor.BackColor = Color.DodgerBlue;
            btnSkor.FlatAppearance.BorderSize = 0;
            btnSkor.FlatStyle = FlatStyle.Flat;
            btnSkor.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSkor.ForeColor = Color.White;
            btnSkor.Location = new Point(252, 331);
            btnSkor.Name = "btnSkor";
            btnSkor.Size = new Size(163, 36);
            btnSkor.TabIndex = 1;
            btnSkor.Text = "Sıralamalar";
            btnSkor.UseMnemonic = false;
            btnSkor.UseVisualStyleBackColor = false;
            btnSkor.Click += btnSkor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(612, 612);
            Controls.Add(lblTitle);
            Controls.Add(textBox1);
            Controls.Add(btnSkor);
            Controls.Add(btnPlay);
            Name = "Form1";
            Text = "Giriş Ekranı";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnSkor;
    }
}
