using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace NDP_Odev.Models
{
    public static class ShapeManager
    {
        public static List<Shape> NormalShapes { get; private set; } = new List<Shape>();
        public static List<Shape> JokerShapes { get; private set; } = new List<Shape>();

        static ShapeManager()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

            // Normal Taşlar
            NormalShapes.Add(new Shape("Kare", Path.Combine(basePath, "kare.png")));
            NormalShapes.Add(new Shape("Kalp", Path.Combine(basePath, "kalp.png")));
            NormalShapes.Add(new Shape("Elips", Path.Combine(basePath, "elips.png")));
            NormalShapes.Add(new Shape("Beşgen", Path.Combine(basePath, "besgen.png")));
            NormalShapes.Add(new Shape("Muz", Path.Combine(basePath, "muz.png")));
            NormalShapes.Add(new Shape("Erik", Path.Combine(basePath, "erik.png")));

            // Joker Taşlar
            JokerShapes.Add(new Shape("Gökkuşağı", Path.Combine(basePath, "gokkusagi.png"), true, JokerType.Rainbow));
            JokerShapes.Add(new Shape("Helikopter", Path.Combine(basePath, "helikopter.png"), true, JokerType.Helicopter));
            JokerShapes.Add(new Shape("Roket", Path.Combine(basePath, "roket.png"), true, JokerType.Rocket));
            JokerShapes.Add(new Shape("Yangın Musluğu", Path.Combine(basePath, "yangın.png"), true, JokerType.FireHydrant));
        }

        public static Shape GetRandomShape()
        {
            Random random = new Random();

            if (random.Next(1, 21) == 1) // %5 Joker Olasılığı
            {
                return JokerShapes[random.Next(JokerShapes.Count)];
            }
            else
            {
                return NormalShapes[random.Next(NormalShapes.Count)];
            }
        }
    }
}
