using NDP_Odev.Models;
using NDP_Odev.Services;

namespace NDP_Odev
{
    public partial class GameScreen : Form
    {
        private int timerCount = 60;
        private int score = 0;
        private string playerName;
        private bool isPaused = false;

        public GameScreen(string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            lblPlayer.Text = $"Oyuncu: {playerName}";
            InitializeGameBoard();
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timerCount--;
            lblTimer.Text = $"Süre: {timerCount}";
            if (timerCount <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show($"Oyun Bitti! Toplam Skorunuz: {score}");

                HighScoreManager.AddHighScore(playerName, score);
                HighScoreManager.LoadHighScores();

                HighScoreForm highScoreForm = new HighScoreForm();
                highScoreForm.ShowDialog();

                this.Close();
            }
        }

        private void InitializeGameBoard()
        {
            int tileSize = 50; // Her kutucuk boyutu
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Button tile = new Button();
                    tile.Size = new Size(tileSize, tileSize);
                    tile.Location = new Point(col * tileSize, row * tileSize);
                    tile.FlatStyle = FlatStyle.Flat;
                    tile.Tag = ShapeManager.GetRandomShape();

                    Shape shape = (Shape)tile.Tag;
                    tile.BackgroundImage = shape.Icon;
                    tile.BackgroundImageLayout = ImageLayout.Stretch;

                    if (shape.IsJoker)
                        tile.BackColor = Color.Gold;

                    tile.Click += Tile_Click;

                    gamePanel.Controls.Add(tile);
                }
            }
        }

        private Button selectedTile = null;

        private async void Tile_Click(object sender, EventArgs e)
        {
            if (isPaused) return;

            Button clickedTile = sender as Button;
            Shape clickedShape = clickedTile?.Tag as Shape;

            if (clickedShape != null && clickedShape.IsJoker)
            {
                int jokerScore = await JokerLogic.ActivateJoker(clickedTile, gamePanel);
                score += jokerScore;
                lblScore.Text = $"Skor: {score}";

                await GameLogic.CheckAndHandleMatches(gamePanel, this.BackColor);
                return;
            }

            if (selectedTile == null)
            {
                selectedTile = clickedTile;
                selectedTile.BackColor = Color.Yellow;
            }
            else
            {
                if (GameLogic.AreAdjacent(selectedTile, clickedTile))
                {
                    GameLogic.SwapTiles(selectedTile, clickedTile);
                    int gainedScore = await GameLogic.CheckAndHandleMatches(gamePanel, this.BackColor);

                    score += gainedScore;
                    lblScore.Text = $"Skor: {score}";
                }
                else
                {
                    MessageBox.Show("Taşlar yalnızca yatay veya dikey olarak komşusuyla yer değiştirebilir!");
                }

                selectedTile.BackColor = Color.Transparent;
                selectedTile = null;
            }
        }



        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                gameTimer.Stop();
                MessageBox.Show("Oyun duraklatıldı, işlem yapamazsınız. Oynamak için devam butonuna basınız.");
                isPaused = true;
            }
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
                gameTimer.Start();
                isPaused = false;
        }
    }
}
