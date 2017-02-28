using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Achivements;
using RPG.Model.Battle;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.ViewModel
{
    public class SettleViewModel : BindableBase
    {
        #region Properties

        public ObservableCollection<IAchievement> Achivements
        {
            get { return _achivements; }
            set
            {
                _achivements = value;
                BindingOperations.EnableCollectionSynchronization(_achivements, _threadLock);
            }
        }

        #endregion

        public SettleViewModel(IEnumerable<IAchievement> achivements)
        {
            Achivements = new ObservableCollection<IAchievement>(achivements);
        }

        public SettleViewModel()
        {
            var userBattleState = new UserBattleState(new UserState());
            Achivements = new ObservableCollection<IAchievement>
            {
                new AchievementFirstBlood(userBattleState),
                new AchievementFirstBlood(userBattleState),
                new AchievementFirstBlood(userBattleState)
            };
        }

        #region Fields

        private readonly object _threadLock = new object();
        private ObservableCollection<IAchievement> _achivements;

        #endregion
    }
}