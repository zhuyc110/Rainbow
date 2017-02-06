using System;

namespace RPG.Model.Battle
{
    public class BattleRoundArgs : EventArgs
    {
        public BattleRoundArgs(int damage)
        {
            Damage = damage;
        }

        public int Damage { get; }
    }
}