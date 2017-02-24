﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public class AchievementBossKiller : AchievementBase
    {
        [ImportingConstructor]
        public AchievementBossKiller([ImportMany] IEnumerable<IBattleProperty> userProperties)
        {
            Enhancements = userProperties;
            Name = "Boss Killer";
            Content = "杀死关卡boss10w次";
            AchivementProperties = new List<AchivementPropertyBase>
            {
                new AchivementPropertyBase("暴击", 0, 0.02),
                new AchivementPropertyBase("暴伤", 0, 0.02),
                new AchivementPropertyBase("金币", 0, 0.02)
            };
            ComposeProperty();
            Condition = 100000;
            IconResource = "Spell_Shadow_BlackPlague";
        }

        public override bool CanHandleEvent<T>(T args)
        {
            if (Achived)
            {
                return false;
            }

            var battle = args as Battle.BattleFinishedArgs;
            if (battle == null)
            {
                return false;
            }

            return false;
        }

        public override void HandleEvent()
        {
            Current++;
        }
    }
}