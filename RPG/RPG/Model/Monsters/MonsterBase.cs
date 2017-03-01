using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Monsters
{
    public abstract class MonsterBase : BindableBase, IMonster
    {
        #region Fields

        private int _currentAttack;
        private int _currentHp;

        #endregion

        #region Properties

        protected IRandom MyRandom { get; set; }

        protected IEnumerable<IBattleProperty> Properties { get; set; }

        #endregion

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

        #region IMonster Members

        public virtual IEnumerable<ISkill> Skills => Enumerable.Empty<ISkill>();

        public int CurrentAttack
        {
            get { return _currentAttack; }
            set { SetProperty(ref _currentAttack, value); }
        }

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
            => CurrentHp / (double) MaximumHp * 100.0;

        public int MaximumHp => Properties.Single(x => x.Name == "生命").FinalValue;

        public MonsterClass Class { get; }
        public IEnumerable<string> DropList { get; protected set; }

        public string IconResource { get; }
        public int Level { get; }
        public string MonsterName { get; }

        public abstract IMonster NewInstance();

        public string Title { get; }

        #endregion

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