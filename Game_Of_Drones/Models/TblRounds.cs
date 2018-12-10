using System;
using System.Collections.Generic;

namespace Game_Of_Drones.Models
{
    public partial class TblRounds
    {
        public int RoundId { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }
        public string FirstPlayerMove { get; set; }
        public string SecondPlayerMove { get; set; }
        public string Winner { get; set; }
    }
}
