using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Game_Of_Drones.Models;
using Game_Of_Drones.DataAccess;
using Game_Of_Drones.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [Route("api/Score/GetScores")]
        public IEnumerable<TblScores> Details()
        {
            return _scoreDao.GetHighScores();
        }
    
    }
}
