using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Game_Of_Drones.Services
{
    public class ScoreDao : IScoreDao
    {
        private masterContext db;
        private ILogger _logger;

        public ScoreDao(masterContext dataBase, ILogger<ScoreDao> logger)
        {
            db = dataBase;
            _logger = logger;
        }

        public List<TblScores> GetHighScores()
        {
            List<TblScores> lstScores = new List<TblScores>();
            lstScores = (from ScoreList in db.TblScores select ScoreList).ToList();

            _logger.LogInformation("retrieving list of high scores to the view");

            return lstScores;
        }

        public void setNewScore(string winner)
        {
            TblScores oldScore = db.TblScores.FirstOrDefault(x => x.PlayerName == winner);

            if (oldScore != null)
            {
                oldScore.GamesWon++;
                try
                {
                    db.Entry(oldScore).State = EntityState.Modified;

                    _logger.LogInformation("If a player with the same name existed the corresponding record is updated instead of creating a new one");

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception happened:" + ex.Message, ex);
                    throw;
                }
            }
            else
            {
                TblScores newScore = new TblScores();
                newScore.PlayerName = winner;
                newScore.GamesWon = 1;
                try
                {
                    db.Add(newScore);
                    db.SaveChanges();
                    _logger.LogInformation("if the player name didn't existed the score is a new record.");

                }
                catch(Exception ex)
                {
                    _logger.LogError("Exception happened:" + ex.Message, ex);
                    throw;
                }
            }
            try
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [tblrounds]");
                _logger.LogInformation("Table rounds truncated to start a new game");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception happened:" + ex.Message, ex);
                throw;
            }
        }
    }
}
