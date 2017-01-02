namespace RPG.Model.Skills
{
    public class Fury : SkillBase
    {
        public Fury()
        {
            Content = "对敌人造成100%伤害，降低敌人30%攻击，持续2回合";
            LevelRequirement = 16;
            Name = "狂怒";
            IconResource = "BTNUnholyFrenzy";
        }
    }
}