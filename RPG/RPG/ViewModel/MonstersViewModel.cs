using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(MonstersViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MonstersViewModel : BindableBase
    {
        [ImportMany]
        public ObservableCollection<IMonster> Monsters { get; set; }
    }
}
