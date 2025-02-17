using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_Odev.Models
{
    public class HighScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public HighScore(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}
