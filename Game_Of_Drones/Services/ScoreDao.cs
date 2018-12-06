using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;

namespace Game_Of_Drones.Services
{
    public class ScoreDao : IScoreDao
    {
        private dronesContext db ;

        public ScoreDao(dronesContext dataBase)
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
