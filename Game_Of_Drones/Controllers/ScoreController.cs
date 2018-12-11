using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Game_Of_Drones.Models;
using Game_Of_Drones.Services;


namespace Game_Of_Drones.Controllers
{
    public class ScoreController : Controller
    {
        private IScoreDao _scoreDao;


        public ScoreController(IScoreDao scoreDao)
        {
            _scoreDao = scoreDao;
        }

        [HttpGet]
        [Route("api/ScoreController/GetScores")]
        public IEnumerable<TblScores> Details()
        {
            return _scoreDao.GetHighScores();
        }

        [HttpGet]
        [Route("api/ScoreController/SetNewScore/{winner}")]
        public string SetNewScore(string winner)
        {
            try
            {
                _scoreDao.setNewScore(winner);
                return "New Score inserted correctly and we have a winner";
            }
            catch(Exception ex)
            {
                return "An exception happened with message:" + ex.Message;
            }
        }



    }
}
