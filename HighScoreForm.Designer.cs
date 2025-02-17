
namespace NDP_Odev
{
    partial class HighScoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private ListView listViewHighScores;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnBack;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScoreForm));
            lblTitle = new Label();
            listViewHighScores = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Comic Sans MS", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(89, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(303, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "En Yüksek Skorlar";
            // 
            // listViewHighScores
            // 
            listViewHighScores.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewHighScores.Font = new Font("Comic Sans MS", 12F);
            listViewHighScores.FullRowSelect = true;
            listViewHighScores.GridLines = true;
            listViewHighScores.Location = new Point(42, 70);
            listViewHighScores.Name = "listViewHighScores";
            listViewHighScores.Size = new Size(400, 300);
            listViewHighScores.TabIndex = 0;
            listViewHighScores.UseCompatibleStateImageBehavior = false;
            listViewHighScores.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Oyuncu Adı";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Skor";
            columnHeader2.Width = 100;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(180, 390);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(127, 36);
            btnBack.TabIndex = 1;
            btnBack.Text = "Geri Dön";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // HighScoreForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(481, 451);
            Controls.Add(listViewHighScores);
            Controls.Add(lblTitle);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "HighScoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sıralama Ekranı";
            Load += HighScoreForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}