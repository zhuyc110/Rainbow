using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Export(typeof(UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase
    {
        private int _currentHp;

        [Import]
        public IUserState UserState { get; set; }

        [ImportingConstructor]
        public UserBattleState()
        {
        }

        [ImportMany(typeof(IBattleProperty))]
        public ObservableCollection<IBattleProperty> UserProperty { get; set; }

        public double CurrentHpPercentage => CurrentHp / (double)UserProperty.Single(x => x.Name == "生命").FinalValue * 100.0;

        public int CurrentHp
        {
            get { return _currentHp; }
            set
            {
                SetProperty(ref _currentHp, value);
                OnPropertyChanged(nameof(CurrentHpPercentage));
            }
        }
    }
}