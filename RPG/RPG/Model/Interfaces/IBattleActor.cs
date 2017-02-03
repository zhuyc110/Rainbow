using System;

namespace RPG.Model.Interfaces
{
    public interface IBattleActor
    {
        event EventHandler BattleFinished;
        void StartBattle(UserBattleState userBattleState, IMonster monster);
    }
}