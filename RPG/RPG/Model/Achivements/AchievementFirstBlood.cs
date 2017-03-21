using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Battle;
using RPG.Model.UserProperties;

namespace RPG.Model.Achivements
{
    public class AchievementFirstBlood : AchievementBase
    {
        [ImportingConstructor]
        public AchievementFirstBlood(UserBattleState userBattleState)
            : base(userBattleState.UserProperty,
                "First blood!",
                "你杀了一只怪物！",
                new List<BasicProperty>
                {
                    new BasicProperty("命中", 0, 0.01),
                    new BasicProperty("生命", 10, 0.00)
                },
                1,
                "Ability_Druid_Disembowel")
        {
        }

        public override bool CanHandleEvent<T>(T args)
        {
            if (Achived)
                return false;

            var battle = args as BattleFinishedArgs;
            if (battle == null)
                return false;

            return battle.IsUserVictoried;
        }

        public override void HandleEvent()
        {
            Current = 1;
        }
    }
}