using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;

namespace Game_Of_Drones.Services
{
    public class ScoreDao : IScoreDao
    {
        private masterContext db;

        public ScoreDao(masterContext dataBase)
        {
            db = dataBase;
        }

        public List<TblScores> GetHighScores()
        {
            List<TblScores> lstScores = new List<TblScores>();
            lstScores = (from ScoreList in db.TblScores select ScoreList).ToList();

            return lstScores;
        }
    }
}
