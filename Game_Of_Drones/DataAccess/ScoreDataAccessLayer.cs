using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;

namespace Game_Of_Drones.DataAccess
{
    public class ScoreDataAccessLayer
    {
        private dronesContext _db;

        public ScoreDataAccessLayer()
        {
        }

        public ScoreDataAccessLayer(dronesContext db)
        {
            _db = db;
        }

        public List<TblScores> GetHighScores()
        {
            List<TblScores> lstScores = new List<TblScores>();
            lstScores = (from ScoreList in _db.TblScores select ScoreList).ToList();

            return lstScores;
        }
    }
}
