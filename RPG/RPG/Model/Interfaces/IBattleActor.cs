using System;
using RPG.Model.Battle;

namespace RPG.Model.Interfaces
{
    public interface IBattleActor
    {
        event EventHandler<BattleFinishedArgs> BattleFinished;
        void StartBattle(UserBattleState userBattleState, IMonster monster);
    }
}