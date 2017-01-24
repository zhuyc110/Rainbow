using System.Collections.Generic;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Monsters
{
    public abstract class MonsterBase : IMonster
    {
        protected MonsterBase(string monsterName, int level, string iconResource, IRandom random, string title = null,
            MonsterClass monsterClass = MonsterClass.Normal)
        {
            MyRandom = random;
            MonsterName = monsterName;
            Level = level;
            IconResource = iconResource;
            Title = title;
            if (monsterClass == MonsterClass.Normal)
                Class = CalculateMonsterClass();
            else
                Class |= CalculateMonsterClass();
        }
        
        protected IEnumerable<IBattleProperty> Properties { get; set; }
        
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