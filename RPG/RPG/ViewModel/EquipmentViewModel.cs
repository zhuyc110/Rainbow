using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof (EquipmentViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentViewModel : BindableBase
    {
        public ObservableCollection<IItem> Equipments { get; }

        [ImportingConstructor]
        public EquipmentViewModel([ImportMany] IEnumerable<EquipmentBase> equipments)
        {
            Equipments = new ObservableCollection<IItem>();
            foreach (var item in equipments.OrderBy(x => x.Rarity))
            {
                Equipments.Add(item);
            }
        }

        [Obsolete("This is ONLY used for Design view")]
        public EquipmentViewModel()
        {
            Equipments = new ObservableCollection<IItem>
            {
                new BasicLance(),
                new BasicLance(),
                new BasicLance(),
                new BasicLance(),
                new BasicLance(),
                new BasicLance(),
                new BasicLance(),
                new BasicLance()
            };
        }
    }
}