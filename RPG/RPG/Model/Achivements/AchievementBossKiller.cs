using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Battle;
using RPG.Model.UserProperties;

namespace RPG.Model.Achivements
{
    public class AchievementBossKiller : AchievementBase
    {
        [ImportingConstructor]
        public AchievementBossKiller(UserBattleState userBattleState)
            : base(userBattleState.UserProperty, 
                  "Boss Killer", 
                  "杀死关卡boss10w次",
                new List<BasicProperty>
                {
                    new BasicProperty("暴击", 0, 0.02),
                    new BasicProperty("暴伤", 0, 0.02),
                    new BasicProperty("金币", 0, 0.02)
                }, 
                100000, 
                "Spell_Shadow_BlackPlague")
        {
        }

        public override bool CanHandleEvent<T>(T args)
        {
            if (Achived)
                return false;

            var battle = args as BattleFinishedArgs;
            if (battle?.Monster == null)
                return false;

            return battle.Monster.Class.HasFlag(MonsterClass.Boss);
        }

        public override void HandleEvent()
        {
            Current++;
        }
    }
}