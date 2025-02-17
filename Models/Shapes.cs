using System.Drawing;

namespace NDP_Odev.Models
{
    public class Shape
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
        public bool IsJoker { get; set; }
        public JokerType? JokerAbility { get; set; }
        public string ImagePath { get; set; } // Orijinal yol için yedekleme

        public Shape(string name, string imagePath, bool isJoker = false, JokerType? ability = null)
        {
            Name = name;
            ImagePath = imagePath;
            IsJoker = isJoker;
            JokerAbility = ability;

            try
            {
                Icon = Image.FromFile(imagePath); // Dosyayı Image olarak yükle
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Shape Icon yüklenemedi: {imagePath}, {ex.Message}");
            }
        }
    }

    public enum JokerType
    {
        Rainbow,    // Gökkuşağı
        Helicopter, // Helikopter
        Rocket,     // Roket
        FireHydrant // Yangın Musluğu
    }
}
