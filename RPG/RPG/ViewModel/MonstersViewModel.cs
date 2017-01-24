using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using RPG.Infrastructure.Implementation;
using RPG.Model.Interfaces;
using RPG.Model.Monsters;

namespace RPG.ViewModel
{
    public class MonstersViewModel : BindableBase
    {
        public MonstersViewModel(IEnumerable<IMonster> monsters)
        {
            Monsters = new ObservableCollection<IMonster>(monsters);
        }

        [Obsolete]
        public MonstersViewModel()
        {
            Monsters = new ObservableCollection<IMonster>
            {
                new MonsterSlime(new MyRandom())
            };
        } 

        public ObservableCollection<IMonster> Monsters { get; private set; }
    }
}