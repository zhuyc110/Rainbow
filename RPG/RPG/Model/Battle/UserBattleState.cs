using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Battle
{
    [Export(typeof(UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase, IBattleEntity
    {
        #region Fields

        private int _currentAttack;
        private int _currentHp;

        #endregion

        #region Properties

        public ObservableCollection<IBattleProperty> UserProperty { get; private set; }
        
        public IUserState UserState { get; }

        #endregion

        [ImportingConstructor]
        public UserBattleState(IUserState userState)
        {
            UserState = userState;
            UserState.LevelUp += (sender, args) => Initialize();
            Initialize();
        }

        #region IBattleEntity Members

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

        public int MaximumHp => UserProperty.Single(x => x.Name == "生命").FinalValue;

        #endregion

        private void Initialize()
        {
            UserProperty = new ObservableCollection<IBattleProperty>
            {
                new PropertyHp(UserState),
                new PropertyAttack(UserState)
            };
            CurrentHp = MaximumHp;
            CurrentAttack = UserProperty.Single(x => x.Name == "攻击").FinalValue;
        }

        public UserBattleState ResetBattleState()
        {
            Initialize();
            return this;
        }
    }
}