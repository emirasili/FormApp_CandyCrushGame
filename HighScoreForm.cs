using NDP_Odev.Models;
using NDP_Odev.Services;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NDP_Odev
{
    public partial class HighScoreForm : Form
    {
        public HighScoreForm()
        {
            InitializeComponent();
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            HighScoreManager.LoadHighScores();
            RoundButton(btnBack);
            this.ActiveControl = btnBack;
            DisplayHighScores();
        }

        private void DisplayHighScores()
        {
            var highScores = HighScoreManager.GetTopHighScores();

            listViewHighScores.Items.Clear();

            foreach (var score in highScores)
            {
                ListViewItem item = new ListViewItem(score.PlayerName);
                item.SubItems.Add(score.Score.ToString());
                listViewHighScores.Items.Add(item);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoundButton(Button button)
        {
            int radius = 15;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(0, 0, radius, radius, 180, 90); // Sol üst köşe
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // Sağ üst köşe
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // Sağ alt köşe
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // Sol alt köşe
            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }
    }
}
