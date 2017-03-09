namespace RPG.Model.Skills
{
    public class Fury : SkillBase
    {
        public Fury()
            : base("狂怒", "对敌人造成100%伤害，降低敌人30%攻击，持续2回合", "BTNUnholyFrenzy", 16, 0.05, SkillEffect.Weak)
        {
        }
    }
}