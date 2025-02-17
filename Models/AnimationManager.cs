using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_Odev.Models
{
    public static class AnimationManager
    {
        /// <summary>
        /// Şeffaf baloncuk patlama efekti uygular.
        /// </summary>
        public static async Task PlayBubbleExplosionAnimation(List<Button> tiles, Color backgroundColor)
        {
            foreach (var tile in tiles)
            {
                tile.BackColor = backgroundColor;
                tile.BackgroundImage = null;
                tile.Tag = null;

                // Hafif şeffaf bir baloncuk efekti
                for (int i = 0; i < 3; i++)
                {
                    tile.BackColor = Color.FromArgb(50 + (i * 50), backgroundColor); 
                    await Task.Delay(100);
                }

                tile.BackColor = backgroundColor;
            }
        }
    }
}
