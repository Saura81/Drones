using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Of_Drones.Services
{
    public class GameDao : IGameDao
    {
        private masterContext db;

        public GameDao(masterContext dataBase)
        {
            db = dataBase;
        }

        public IEnumerable<TblMoves> GetMoveSet()
        {
            List<TblMoves> lstMoves = new List<TblMoves>();
            lstMoves = (from MoveList in db.TblMoves select MoveList).ToList();

            return lstMoves;
        }

        public TblRounds GetRoundData(int id)
        {
            try
            {
                TblRounds round = db.TblRounds.Find(id);
                return round;
            }
            catch
            {
                throw;
            }
        }

        public string PlayerOneBeatsTwo(TblRounds updatedRound)
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
                return round.RoundId;

            }
            catch
            {
                throw;
            }
        }

        public int saveRound(TblRounds round)
        {
            try
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();
                return round.RoundId;
            }
            catch
            {
                throw;
            }
        }

        public bool HaveWinner(TblRounds round)
        {
            bool weHaveWinner = db.TblRounds.Count(x => x.Winner == round.FirstPlayerName) == 3 ||
                db.TblRounds.Count(x => x.Winner == round.SecondPlayerName) == 3 ? true : false;
            return weHaveWinner;
        }

        public TblRounds getRoundInProgress()
        {
            return db.TblRounds.LastOrDefault();
        }

        public List<TblRounds> getAllCompletedRounds()
        {
            List<TblRounds> lstRounds = new List<TblRounds>();
            lstRounds = (from RoundList in db.TblRounds where !string.IsNullOrEmpty(RoundList.Winner) select RoundList).ToList();
            return lstRounds;

        }
    }
}
