namespace RPG.Model.Skills
{
    public class Whirlwind : SkillBase
    {
        public Whirlwind()
        {
            Name = "旋风斩";
            Content = "对敌人造成2次60%伤害使目标眩晕1回合";
            LevelRequirement = 24;
        }
    }
}