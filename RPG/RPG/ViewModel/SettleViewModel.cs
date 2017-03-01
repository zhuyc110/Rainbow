using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Prism.Mvvm;
using RPG.Model.Interfaces;

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

        #region Fields

        private readonly object _threadLock = new object();
        private ObservableCollection<IAchievement> _achivements;

        #endregion
    }
}