using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Monsters
{
    public abstract class MonsterBase : IMonster
    {
        public string Title { get; protected set; }
        public string MonsterName { get; protected set; }
        public int Level { get; protected set; }
        public MonsterClass Class { get; protected set; }

        [Import]
        protected IRandom MyRandom { get; set; }

        protected MonsterBase(string monsterName, int level, string title = null, MonsterClass monsterClass = MonsterClass.Normal)
        {
            MonsterName = monsterName;
            Level = level;
            if (monsterClass == MonsterClass.Normal)
            {
                Class = CalculateMonsterClass();
            }
            else
            {
                Class |= CalculateMonsterClass();
            }
        }

        private MonsterClass CalculateMonsterClass()
        {
            var random = MyRandom.Next(100);

            if (random > 95)
            {
                return MonsterClass.Variation;
            }
            if (random > 85)
            {
                return MonsterClass.Elite;
            }
            return  MonsterClass.Normal;
        }
    }
}