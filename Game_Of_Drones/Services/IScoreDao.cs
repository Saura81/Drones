using Game_Of_Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Drones.Services
{
    public interface IScoreDao
    {
        List<TblScores> GetHighScores();
    }
}
