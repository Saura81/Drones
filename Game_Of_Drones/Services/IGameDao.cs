using Game_Of_Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Drones.Services
{
    public interface IGameDao
    {

        int StartNewRound(TblRounds round);

        TblRounds GetRoundData(int id);

        IEnumerable<TblMoves> GetMoveSet();

        string PlayerOneBeatsTwo(TblRounds updatedRound);

        int saveRound(TblRounds round);

        bool HaveWinner(TblRounds round);

        TblRounds getRoundInProgress();

        List<TblRounds> getAllCompletedRounds();
    }
}
