using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    public class EquipmentDetailViewModel : BindableBase
    {
        public EquipmentBase Equipment { get; }

        public ICommand EnchantCommand { get; }

        public EquipmentDetailViewModel(EquipmentBase equipment, IEnchantmentManager enchantmentManager)
        {
            Equipment = equipment;

            EnchantCommand = new DelegateCommand(() =>
            {
                enchantmentManager.Enchant(Equipment);
            });
        }

        [Obsolete]
        public EquipmentDetailViewModel()
        {
            Equipment = new BasicLance();
        }
    }
}