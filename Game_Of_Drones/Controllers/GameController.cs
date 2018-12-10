using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game_Of_Drones.Models;
using Game_Of_Drones.Services;
using Microsoft.AspNetCore.Mvc;
using Game_Of_Drones.Helpers;


namespace Game_Of_Drones.Controllers
{
    public class GameController : Controller
    {
        private IGameDao _gameDao;


        public GameController(IGameDao gameDao)
        {
            _gameDao = gameDao;
        }


        [HttpPost]
        [Route("api/GameController/CreateGame")]
        public int CreateGame(TblRounds newGame)
        {
            return _gameDao.StartNewRound(newGame);
        }

        [HttpGet]
        [Route("api/GameController/GetCurrentRound/{id}")]
        public string GetCurrentRound(int id)
        {
            var round =_gameDao.GetRoundData(id);
            if (string.IsNullOrEmpty(round.FirstPlayerMove))
            {
                return round.FirstPlayerName;
            }
            else
            {
                return round.SecondPlayerName;
            }
            
        }

        [HttpGet]
        [Route("api/GameController/GetMoveSet")]
        public IEnumerable<TblMoves> GetMoveSet()
        {
            return _gameDao.GetMoveSet();
        }

        [HttpPost]
        [Route("api/GameController/EditRound")]
        public List<string> EditRound(int roundId,string  move)
        {
            var roundInProgress = updateRoundPlayerData(move);

            List<string> callback = new List<string>();
            
            if (string.IsNullOrEmpty(roundInProgress.Winner))
            {
             
                callback.Add(_gameDao.saveRound(roundInProgress).ToString());

                if (string.IsNullOrEmpty(roundInProgress.FirstPlayerMove))
                {
                    callback.Add(roundInProgress.FirstPlayerName);
                }
                else
                {
                    callback.Add(roundInProgress.SecondPlayerName);
                }
            }
            else
            {               
                _gameDao.saveRound(roundInProgress);

                if (_gameDao.HaveWinner(roundInProgress))
                {
                    return callback;
                }
                else
                {
                    var newRound = _gameDao.StartNewRound(new TblRounds
                    {
                        FirstPlayerName = roundInProgress.FirstPlayerName,
                        SecondPlayerName = roundInProgress.SecondPlayerName

                    });
                    callback.Add(newRound.ToString());
                    callback.Add(roundInProgress.FirstPlayerName);
                }
                
            }

            return callback;
        }

        [HttpGet]
        [Route("api/GameController/GetGameScores")]
        public IEnumerable<Score> GetGameScores()
        {
            var lstRounds = _gameDao.getAllCompletedRounds();
            List<Score> roundList = new List<Score>();
            foreach (var round in lstRounds)
            {
                roundList.Add(new Score
                {
                    round = round.RoundId.ToString(),
                    winner = round.Winner
                });
            }
            return roundList;
        }

        private TblRounds updateRoundPlayerData(string playerMove)
        {
            TblRounds updatedRound = _gameDao.getRoundInProgress();

            if (string.IsNullOrEmpty(updatedRound.FirstPlayerMove))
            {
                updatedRound.FirstPlayerMove = playerMove;

                return updatedRound;
            }
            else
            {
                updatedRound.SecondPlayerMove = playerMove;

                updatedRound.Winner = _gameDao.PlayerOneBeatsTwo(updatedRound);

                return updatedRound;
                 
            }
        }


}
}
