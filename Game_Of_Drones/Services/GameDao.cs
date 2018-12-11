using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Game_Of_Drones.Services
{
    public class GameDao : IGameDao
    {
        private masterContext db;
        private ILogger _logger;

        public GameDao(masterContext dataBase, ILogger<GameDao> logger)
        {
            db = dataBase;
            _logger = logger;
        }

        public IEnumerable<TblMoves> GetMoveSet()
        {
            List<TblMoves> lstMoves = new List<TblMoves>();
            lstMoves = (from MoveList in db.TblMoves select MoveList).ToList();

            _logger.LogInformation("retrieving list of moves to fill up the select item component in round page.");
            return lstMoves;
        }

        public TblRounds GetRoundData(int id)
        {
            try
            {
                TblRounds round = db.TblRounds.Find(id);
                _logger.LogInformation("returning round entity to view");
                return round;

            }
            catch(Exception ex)
            {
                _logger.LogError("Exception happened:" + ex.Message, ex);
                throw;
            }
        }

        public string CheckingHands(TblRounds updatedRound)
        {
            TblMoves playerOneMove = db.TblMoves.FirstOrDefault(x => x.MoveName == updatedRound.FirstPlayerMove);
            TblMoves playerTwoMove = db.TblMoves.FirstOrDefault(x => x.MoveName == updatedRound.SecondPlayerMove);

            if (playerOneMove.MoveId == playerTwoMove.Kills)
            {
                return updatedRound.SecondPlayerName;
            }
            else if (playerOneMove.Kills == playerTwoMove.MoveId)
            {
                return updatedRound.FirstPlayerName;

            }
            return "draw";

        }

        public int StartNewRound(TblRounds round)
        {
            try
            {
                round.FirstPlayerMove = "";
                round.SecondPlayerMove = "";
                round.Winner = "";
                db.Add(round);
                db.SaveChanges();

                _logger.LogInformation("New Round create with default values.");
                return round.RoundId;

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception happened:" + ex.Message, ex);
                throw;
            }
        }

        public int saveRound(TblRounds round)
        {
            try
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();

                _logger.LogInformation("Saved changes to round in progress.");
                return round.RoundId;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception happened:" + ex.Message, ex);
                throw;
            }
        }

        public string HaveWinner(TblRounds round)
        {

            if (db.TblRounds.Count(x => x.Winner == round.FirstPlayerName) == 3)
            {
                return round.FirstPlayerName;

            }
            else if (db.TblRounds.Count(x => x.Winner == round.SecondPlayerName) == 3)
            {
                return round.SecondPlayerName;
                
            }
            else
            {
                return "";
            }
        }

        public TblRounds getRoundInProgress()
        {
            return db.TblRounds.LastOrDefault();
        }

        public List<TblRounds> getAllCompletedRounds()
        {
            List<TblRounds> lstRounds = new List<TblRounds>();
            lstRounds = (from RoundList in db.TblRounds where !string.IsNullOrEmpty(RoundList.Winner) select RoundList).ToList();

            _logger.LogInformation("returning list of completed rounds to view");
            return lstRounds;

        }

    }
}
