namespace RPG.Model.Skills
{
    public class Fireball : SkillBase
    {
        public Fireball()
            : base("火焰弹", "对敌人造成100%伤害，烧伤目标2回合", "BTNFireBolt", 8, 0.5, SkillEffect.Dot)
        {
        }
    }
}