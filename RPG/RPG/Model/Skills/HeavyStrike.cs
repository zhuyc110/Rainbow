namespace RPG.Model.Skills
{
    public class HeavyStrike : AbstractSkill
    {
        public HeavyStrike()
        {
            Content = "对敌人造成150%伤害";
            Icon = null;
            LevelRequirement = 1;
            Name = "重击";
        }
    }
}