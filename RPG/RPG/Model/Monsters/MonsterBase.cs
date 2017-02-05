using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Monsters
{
    public abstract class MonsterBase : BindableBase, IMonster
    {
        private int _currentAttack;
        private int _currentHp;

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

        public int CurrentAttack
        {
            get { return _currentAttack; }
            set { SetProperty(ref _currentAttack, value); }
        }

        public string Title { get; }
        public string MonsterName { get; }
        public int Level { get; }
        public MonsterClass Class { get; }

        public string IconResource { get; }

        public int CurrentHp
        {
            get { return _currentHp; }
            set
            {
                SetProperty(ref _currentHp, value);
                OnPropertyChanged(nameof(CurrentHpPercentage));
            }
        }

        public double CurrentHpPercentage
            => CurrentHp / (double) Properties.Single(x => x.Name == "生命").FinalValue * 100.0;

        private MonsterClass CalculateMonsterClass()
        {
            var random = MyRandom.Next(100);

            if (random > 95)
                return MonsterClass.Variation;
            if (random > 85)
                return MonsterClass.Elite;
            return MonsterClass.Normal;
        }
    }
}