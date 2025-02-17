using NDP_Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NDP_Odev.Services
{
    public class JokerLogic : GameLogic
    {
        /// <summary>
        /// Joker taşların özel efektlerini tetikler.
        /// </summary>
        public static async Task<int> ActivateJoker(Button jokerTile, Panel gamePanel)
        {
            Shape shape = jokerTile.Tag as Shape;

            if (shape?.JokerAbility == null) return 0;

            int scoreIncrement = 0;

            switch (shape.JokerAbility)
            {
                case JokerType.Rainbow:
                    scoreIncrement = ActivateRainbowEffect(gamePanel, jokerTile);
                    break;
                case JokerType.Helicopter:
                    scoreIncrement = ActivateHelicopterEffect(jokerTile, gamePanel);
                    break;
                case JokerType.Rocket:
                    scoreIncrement = ActivateRocketEffect(jokerTile, gamePanel);
                    break;
                case JokerType.FireHydrant:
                    scoreIncrement = ActivateFireHydrantEffect(jokerTile, gamePanel);
                    break;
            }

            jokerTile.Tag = null;
            jokerTile.BackgroundImage = null;
            jokerTile.BackColor = Color.Transparent;

            await Task.Delay(1000);
            DropTiles(gamePanel);
            scoreIncrement += await CheckAndHandleMatches(gamePanel, Color.Transparent);

            return scoreIncrement; // Joker aktivasyonundan elde edilen puan
        }


        /// <summary>
        /// Rainbow (Gökkuşağı) Joker: Belirli renkteki tüm taşları kaldırır.
        /// </summary>
        private static int ActivateRainbowEffect(Panel gamePanel, Button jokerTile)
        {
            int scoreIncrement = 0;

            Button selectedTile = null;

            void Tile_Click(object sender, EventArgs e)
            {
                selectedTile = sender as Button;
            }

            foreach (Control control in gamePanel.Controls)
            {
                if (control is Button tile)
                    tile.Click += Tile_Click;
            }

            // Seçim bekleniyor
            while (selectedTile == null)
            {
                Application.DoEvents();
            }

            Shape selectedShape = selectedTile.Tag as Shape;
            if (selectedShape == null) return 0;

            foreach (Control control in gamePanel.Controls)
            {
                if (control is Button tile && tile.Tag is Shape tileShape && tileShape.Name == selectedShape.Name)
                {
                    tile.Tag = null;
                    tile.BackgroundImage = null;
                    tile.BackColor = Color.Transparent;
                    scoreIncrement += 10;
                }
            }

            return scoreIncrement;
        }


        /// <summary>
        /// Helicopter (Helikopter) Joker: Rastgele bir taşı ve çevresindekileri patlatır.
        /// </summary>
        private static int ActivateHelicopterEffect(Button jokerTile, Panel gamePanel)
        {
            int row = jokerTile.Location.Y / 50;
            int col = jokerTile.Location.X / 50;

            int scoreIncrement = 0;

            for (int i = row; i < row + 2 && i < 9; i++)
            {
                for (int j = col; j < col + 2 && j < 9; j++)
                {
                    Button tile = GetTileAt(gamePanel, i, j);
                    if (tile != null && tile.Tag != null)
                    {
                        tile.Tag = null;
                        tile.BackgroundImage = null;
                        tile.BackColor = Color.Transparent;
                        scoreIncrement += 10;
                    }
                }
            }

            return scoreIncrement;
        }



        /// <summary>
        /// Rocket (Roket) Joker: Yatay bir sıra temizler.
        /// </summary>
        private static int ActivateRocketEffect(Button jokerTile, Panel gamePanel)
        {
            int scoreIncrement = 0;

            foreach (Control control in gamePanel.Controls)
            {
                if (control is Button tile && (tile.Location.Y == jokerTile.Location.Y))
                {
                    tile.Tag = null;
                    tile.BackgroundImage = null;
                    tile.BackColor = Color.Transparent;
                    scoreIncrement += 10;
                }
            }

            return scoreIncrement;
        }


        /// <summary>
        /// FireHydrant (Yangın Musluğu) Joker: Bir sütunu tamamen temizler.
        /// </summary>
        private static int ActivateFireHydrantEffect(Button jokerTile, Panel gamePanel)
        {
            int col = jokerTile.Location.X / 50;
            int scoreIncrement = 0;

            for (int row = 0; row < 9; row++)
            {
                Button tile = GetTileAt(gamePanel, row, col);
                if (tile != null && tile.Tag != null)
                {
                    tile.Tag = null;
                    tile.BackgroundImage = null;
                    tile.BackColor = Color.Transparent;
                    scoreIncrement += 10;
                }
            }

            return scoreIncrement;
        }
    }
}
