using Prism.Mvvm;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace RPG.ViewModel
{
    [Export(nameof(EquipmentViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentViewModel : BindableBase
    {
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

        public ObservableCollection<IItem> Equipments { get; }
    }
}