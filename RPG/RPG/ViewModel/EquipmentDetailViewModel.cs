using System;
using Prism.Mvvm;
using RPG.Model.Equipment;

namespace RPG.ViewModel
{
    public class EquipmentDetailViewModel : BindableBase
    {
        public EquipmentBase Equipment { get; private set; }

        public EquipmentDetailViewModel(EquipmentBase equipment)
        {
            Equipment = equipment;
        }

        [Obsolete]
        public EquipmentDetailViewModel()
        {
            Equipment = new BasicLance();
        }
    }
}