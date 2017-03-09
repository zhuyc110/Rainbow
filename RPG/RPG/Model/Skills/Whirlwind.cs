namespace RPG.Model.Skills
{
    public class Whirlwind : SkillBase
    {
        public Whirlwind()
            : base("旋风斩", "对敌人造成2次60%伤害使目标眩晕1回合", "BTNStormBolt", 24, 0.05, SkillEffect.Dizziness)
        {
            DamageRatePerAttack = 0.6;
            AttackFrequency = 2;
        }
    }
}