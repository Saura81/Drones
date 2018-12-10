using System;
using System.Collections.Generic;

namespace Game_Of_Drones.Models
{
    public partial class TblMoves
    {
        public int MoveId { get; set; }
        public string MoveName { get; set; }
        public int Kills { get; set; }
    }
}
