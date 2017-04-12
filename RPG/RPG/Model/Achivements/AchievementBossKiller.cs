using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using RPG.Model.Battle;
using RPG.Model.UserProperties;

namespace RPG.Model.Achivements
{
    public class AchievementBossKiller : AchievementBase
    {
        [ImportingConstructor]
        public AchievementBossKiller()
            : base("Boss Killer",
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

        private BattleFinishedArgs BattleFinishedArgs { get; set; }

        public override bool CanHandleEvent<T>(T args)
        {
            BattleFinishedArgs = null;
            if (Achived)
                return false;

            BattleFinishedArgs = args as BattleFinishedArgs;
            if (BattleFinishedArgs?.Monsters == null)
                return false;

            if (!BattleFinishedArgs.IsUserVictoried)
            {
                return false;
            }

            return BattleFinishedArgs.Monsters.Any(x => x.Class.HasFlag(MonsterClass.Boss));
        }

        public override void HandleEvent()
        {
            Current += BattleFinishedArgs.Monsters.Count(x => x.Class.HasFlag(MonsterClass.Boss));
        }
    }
}