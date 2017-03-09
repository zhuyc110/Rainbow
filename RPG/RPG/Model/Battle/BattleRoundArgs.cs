using System;

namespace RPG.Model.Battle
{
    public class BattleRoundArgs : EventArgs
    {
        public BattleEntityAttack AttackEntity { get; }

        public BattleRoundArgs(BattleEntityAttack attackEntity)
        {
            AttackEntity = attackEntity;
        }
    }
}