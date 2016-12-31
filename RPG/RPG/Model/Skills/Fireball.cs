namespace RPG.Model.Skills
{
    public class Fireball : AbstractSkill
    {
        public Fireball()
        {
            Content = "对敌人造成100%伤害，烧伤目标2回合";
            LevelRequirement = 8;
            Name = "火焰弹";
        }
    }
}