using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NDP_Odev.Models
{
    public static class HighScoreManager
    {
        private static List<HighScore> highScores = new List<HighScore>();
        private static readonly string filePath = "highscores.json";

        // Skorları yükle
        public static void LoadHighScores()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                highScores = JsonSerializer.Deserialize<List<HighScore>>(json) ?? new List<HighScore>();
            }
        }

        // Skorları kaydet
        public static void SaveHighScores()
        {
            string json = JsonSerializer.Serialize(highScores);
            File.WriteAllText(filePath, json);
        }

        // Yeni bir skor ekle
        public static void AddHighScore(string playerName, int score)
        {
            highScores.Add(new HighScore(playerName, score));
            highScores = highScores
                .OrderByDescending(s => s.Score)
                .Take(5)
                .ToList();

            SaveHighScores();
        }

        // En yüksek 5 skoru al
        public static List<HighScore> GetTopHighScores()
        {
            return highScores.OrderByDescending(s => s.Score).Take(5).ToList();
        }

    }
}
