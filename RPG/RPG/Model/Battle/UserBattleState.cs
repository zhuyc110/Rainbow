using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    [Export(typeof(UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase, IBattleEntity
    {
        private int _currentAttack;
        private int _currentHp;

        [ImportingConstructor]
        public UserBattleState([ImportMany(typeof(IBattleProperty))] IEnumerable<IBattleProperty> userProperties)
        {
            UserProperty = new ObservableCollection<IBattleProperty>(userProperties);
            Initialize();
        }

        private void Initialize()
        {
            CurrentHp = MaximumHp;
            CurrentAttack = UserProperty.Single(x => x.Name == "攻击").FinalValue;
        }

        [Import]
        public IUserState UserState { get; set; }

        public ObservableCollection<IBattleProperty> UserProperty { get; }

        public double CurrentHpPercentage
            => CurrentHp / (double)MaximumHp * 100.0;

        public int CurrentHp
        {
            get { return _currentHp; }
            set
            {
                SetProperty(ref _currentHp, value);
                OnPropertyChanged(nameof(CurrentHpPercentage));
            }
        }

        public int CurrentAttack
        {
            get { return _currentAttack; }
            set { SetProperty(ref _currentAttack, value); }
        }

        public UserBattleState ResetBattleState()
        {
            Initialize();
            return this;
        }

        public int MaximumHp => UserProperty.Single(x => x.Name == "生命").FinalValue;
    }
}