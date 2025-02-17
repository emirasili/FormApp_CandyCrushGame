using NDP_Odev.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
namespace NDP_Odev.Services
{
    public class GameLogic
    {
        /// <summary>
        /// Taş eşleşmelerini kontrol eder ve patlamayı başlatır.
        /// </summary>
        public static async Task<int> CheckAndHandleMatches(Panel gamePanel, Color backgroundColor)
        {
            List<Button> matchedTiles = new List<Button>();
            int scoreIncrement = 0;

            // Yatay kontrol
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var tile1 = GetTileAt(gamePanel, row, col);
                    var tile2 = GetTileAt(gamePanel, row, col + 1);
                    var tile3 = GetTileAt(gamePanel, row, col + 2);

                    if (tile1.Tag != null && tile1.Tag == tile2.Tag && tile2.Tag == tile3.Tag)
                    {
                        matchedTiles.Add(tile1);
                        matchedTiles.Add(tile2);
                        matchedTiles.Add(tile3);
                    }
                }
            }

            // Dikey kontrol
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 7; row++)
                {
                    var tile1 = GetTileAt(gamePanel, row, col);
                    var tile2 = GetTileAt(gamePanel, row + 1, col);
                    var tile3 = GetTileAt(gamePanel, row + 2, col);

                    if (tile1.Tag != null && tile1.Tag == tile2.Tag && tile2.Tag == tile3.Tag)
                    {
                        matchedTiles.Add(tile1);
                        matchedTiles.Add(tile2);
                        matchedTiles.Add(tile3);
                    }
                }
            }

            if (matchedTiles.Count > 0)
            {
                scoreIncrement = matchedTiles.Count * 10;
                await AnimationManager.PlayBubbleExplosionAnimation(matchedTiles, backgroundColor);
                DropTiles(gamePanel);
                scoreIncrement += await CheckAndHandleMatches(gamePanel, backgroundColor); // Yeni eşleşmeleri kontrol et
            }

            return scoreIncrement;
        }


        protected static Button GetTileAt(Panel panel, int row, int col)
        {
            return panel.Controls[row * 9 + col] as Button;
        }

        /// <summary>
        /// Taşların düşmesini sağlar.
        /// </summary>
        protected static void DropTiles(Panel gamePanel)
        {
            for (int col = 0; col < 9; col++)
            {
                for (int row = 8; row >= 0; row--)
                {
                    var currentTile = GetTileAt(gamePanel, row, col);
                    if (currentTile.Tag == null)
                    {
                        for (int aboveRow = row - 1; aboveRow >= 0; aboveRow--)
                        {
                            var aboveTile = GetTileAt(gamePanel, aboveRow, col);
                            if (aboveTile.Tag != null)
                            {
                                currentTile.Tag = aboveTile.Tag;
                                currentTile.BackgroundImage = aboveTile.BackgroundImage;
                                currentTile.BackColor = aboveTile.BackColor; // Arka plan rengini taşı

                                aboveTile.Tag = null;
                                aboveTile.BackgroundImage = null;
                                aboveTile.BackColor = Color.Transparent; // Üstteki taşın arka plan rengini temizle
                                break;
                            }
                        }
                    }
                }
            }

            // Boş olan kutucuklara yeni nesneler ekle
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    var tile = GetTileAt(gamePanel, row, col);
                    if (tile.Tag == null)
                    {
                        var newShape = ShapeManager.GetRandomShape();
                        tile.Tag = newShape;
                        tile.BackgroundImage = newShape.Icon;
                        tile.BackColor = newShape.IsJoker ? Color.Gold : Color.Transparent;
                    }
                }
            }
        }


        /// <summary>
        /// İki taşın yerini değiştirir.
        /// </summary>
        public static void SwapTiles(Button tile1, Button tile2)
        {
            var tempTag = tile1.Tag;
            var tempImage = tile1.BackgroundImage;
            var tempBackColor = tile1.BackColor; 

            tile1.Tag = tile2.Tag;
            tile1.BackgroundImage = tile2.BackgroundImage;
            tile1.BackColor = tile2.BackColor; 

            tile2.Tag = tempTag;
            tile2.BackgroundImage = tempImage;
            tile2.BackColor = tempBackColor; 
        }

        /// <summary>
        /// İki taşın komşu olup olmadığını kontrol eder.
        /// </summary>
        public static bool AreAdjacent(Button tile1, Button tile2)
        {
            int dx = Math.Abs(tile1.Location.X - tile2.Location.X);
            int dy = Math.Abs(tile1.Location.Y - tile2.Location.Y);

            return (dx == 50 && dy == 0) || (dx == 0 && dy == 50);
        }

    }
}
