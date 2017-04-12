using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RPG.Model.Battle;

namespace RPG.Model.Interfaces
{
    public interface IBattleActor
    {
        event EventHandler<BattleFinishedArgs> BattleFinished;
        event EventHandler<BattleRoundArgs> OneRoundBattle;

        Task StartBattle(IBattleEntity userBattleState, IMonster monster);
        Task StartBattle(IBattleEntity userBattleState, IEnumerable<IMonster> monsters);
    }
}