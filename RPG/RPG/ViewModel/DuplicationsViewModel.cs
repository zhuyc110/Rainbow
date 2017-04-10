using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Mvvm;
using RPG.Infrastructure.Implementation;
using RPG.Model.Interfaces;
using RPG.Model.Monsters;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DuplicationsViewModel : BindableBase
    {
        public ObservableCollection<DuplicationViewModel> Duplications { get; }

        public ICommand StartDuplicationCommand { get; }

        [ImportingConstructor]
        public DuplicationsViewModel([ImportMany] IEnumerable<IMonster> monsters)
        {
            Duplications = new ObservableCollection<DuplicationViewModel>
            {
                new DuplicationViewModel(monsters, 1)
            };
        }

        public DuplicationsViewModel()
        {
            Duplications = new ObservableCollection<DuplicationViewModel>
            {
                new DuplicationViewModel(new[] {new MonsterSlime(new MyRandom())}, 1)
            };
        }
    }
}