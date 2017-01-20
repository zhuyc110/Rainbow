using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Monsters
{
    public abstract class MonsterBase : IMonster
    {
        protected MonsterBase(string monsterName, int level, string iconResource, string title = null,
            MonsterClass monsterClass = MonsterClass.Normal)
        {
            MonsterName = monsterName;
            Level = level;
            Title = title;
            if (monsterClass == MonsterClass.Normal)
                Class = CalculateMonsterClass();
            else
                Class |= CalculateMonsterClass();
        }
        
        protected IEnumerable<IBattleProperty> Properties { get; set; }

        [Import]
        protected IRandom MyRandom { get; set; }

        public string Title { get; }
        public string MonsterName { get; }
        public int Level { get; }
        public MonsterClass Class { get; }

        private MonsterClass CalculateMonsterClass()
        {
            var random = MyRandom.Next(100);

            if (random > 95)
                return MonsterClass.Variation;
            if (random > 85)
                return MonsterClass.Elite;
            return MonsterClass.Normal;
        }

        public string IconResource { get; }
    }
}