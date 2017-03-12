﻿namespace RPG.Model.Skills
{
    public class HeavyStrike : SkillBase
    {
        public HeavyStrike()
            : base("重击", "对敌人造成150%伤害", "BTNCleavingAttack", 1, 0.1)
        {
            DamageRatePerAttack = 1.5;
        }
    }
}