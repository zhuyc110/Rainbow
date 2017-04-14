using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    public class DuplicationViewModel : BindableBase
    {
        private readonly IUserState _userState;
        public ObservableCollection<IMonster> Monsters { get; }

        public int RequiredLevel { get; }

        public bool CanStartuplication => _userState.Level >= RequiredLevel;

        public DuplicationViewModel(IEnumerable<IMonster> monsters, int requiredLevel, IUserState userState)
        {
            _userState = userState;
            Monsters = new ObservableCollection<IMonster>(monsters);
            RequiredLevel = requiredLevel;

            _userState.LevelUp += (sender, args) => OnPropertyChanged(nameof(CanStartuplication));
        }
    }
}