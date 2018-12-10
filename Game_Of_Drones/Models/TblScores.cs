using System;
using System.Collections.Generic;

namespace Game_Of_Drones.Models
{
    public partial class TblScores
    {
        public int ScoreId { get; set; }
        public string PlayerName { get; set; }
        public int? GamesWon { get; set; }
    }
}
