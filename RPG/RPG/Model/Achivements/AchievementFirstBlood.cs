using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public class AchievementFirstBlood : AchievementBase
    {
        [ImportingConstructor]
        public AchievementFirstBlood([ImportMany]IEnumerable<IUserProperty> userProperties)
        {
            Enhancements = userProperties;
            Name = "First blood!";
            Content = "你杀了一只怪物！";
            AchivementProperties = new List<AchivementPropertyBase>
            {
                new AchivementPropertyBase("命中", 0, 0.01),
                new AchivementPropertyBase("暴击", 0, 0.01)
            };
            ComposeProperty();
            Condition = 1;
            IconResource = "Ability_Druid_Disembowel";
        }
    }
}