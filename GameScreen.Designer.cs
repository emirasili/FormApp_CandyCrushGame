using System.Drawing;
using System.Windows.Forms;

namespace NDP_Odev
{
    partial class GameScreen
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTimer;
        private Label lblScore;
        private Label lblPlayer;
        private Panel gamePanel;
        private System.Windows.Forms.Timer gameTimer;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            lblTimer = new Label();
            lblScore = new Label();
            lblPlayer = new Label();
            gamePanel = new Panel();
            gameTimer = new System.Windows.Forms.Timer(components);
            pauseButton = new PictureBox();
            resumeButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resumeButton).BeginInit();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblTimer.Location = new Point(18, 19);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(80, 23);
            lblTimer.TabIndex = 0;
            lblTimer.Text = "Süre: 60";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblScore.Location = new Point(131, 19);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(70, 23);
            lblScore.TabIndex = 1;
            lblScore.Text = "Skor: 0";
            // 
            // lblPlayer
            // 
            lblPlayer.AutoSize = true;
            lblPlayer.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblPlayer.Location = new Point(245, 19);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(78, 23);
            lblPlayer.TabIndex = 2;
            lblPlayer.Text = "Oyuncu: ";
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.LightGray;
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            gamePanel.Location = new Point(12, 56);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(451, 451);
            gamePanel.TabIndex = 3;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // pauseButton
            // 
            pauseButton.BackColor = Color.Transparent;
            pauseButton.BackgroundImage = (Image)resources.GetObject("pauseButton.BackgroundImage");
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.Location = new Point(12, 513);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(52, 50);
            pauseButton.TabIndex = 4;
            pauseButton.TabStop = false;
            pauseButton.Click += pauseButton_Click;
            // 
            // resumeButton
            // 
            resumeButton.BackColor = Color.Transparent;
            resumeButton.BackgroundImage = (Image)resources.GetObject("resumeButton.BackgroundImage");
            resumeButton.BackgroundImageLayout = ImageLayout.Stretch;
            resumeButton.Location = new Point(70, 519);
            resumeButton.Name = "resumeButton";
            resumeButton.Size = new Size(38, 38);
            resumeButton.TabIndex = 4;
            resumeButton.TabStop = false;
            resumeButton.Click += resumeButton_Click;
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(477, 569);
            Controls.Add(resumeButton);
            Controls.Add(pauseButton);
            Controls.Add(lblTimer);
            Controls.Add(lblScore);
            Controls.Add(lblPlayer);
            Controls.Add(gamePanel);
            DoubleBuffered = true;
            Name = "GameScreen";
            Text = "Oyun Ekranı";
            Load += GameScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)resumeButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pauseButton;
        private PictureBox resumeButton;
    }
}
