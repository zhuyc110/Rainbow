using System;
using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    [Export(typeof(IBattleActor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BattleActor: IBattleActor
    {
        public event EventHandler<BattleFinishedArgs> BattleFinished;

        public void StartBattle(UserBattleState userBattleState, IMonster monster)
        {
            throw new NotImplementedException();
        }

        private bool OneRound(UserBattleState userBattleState, IMonster monster)
        {
            return true;
        }
    }
}
