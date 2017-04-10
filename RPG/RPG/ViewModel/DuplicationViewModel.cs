using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    public class DuplicationViewModel : BindableBase
    {
        public ObservableCollection<IMonster> Monsters { get; }

        public int RequiredLevel { get; }

        public DuplicationViewModel(IEnumerable<IMonster> monsters, int requiredLevel)
        {
            Monsters = new ObservableCollection<IMonster>(monsters);
            RequiredLevel = requiredLevel;
        }
    }
}