using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.ViewModel
{
    public class EquipmentDetailViewModel : BindableBase
    {
        public EquipmentBase Equipment { get; }

        public ObservableCollection<BasicProperty> EnchantmentProperties { get; private set; }

        public ICommand EnchantCommand { get; }

        public string EnchantmentLevel => _enchantmentManager.CalculateEnchantLevel(Equipment);

        public int EnchantCost => _enchantmentManager.CalculateCost(Equipment);

        public EquipmentDetailViewModel(EquipmentBase equipment, IEnchantmentManager enchantmentManager)
        {
            Equipment = equipment;
            _enchantmentManager = enchantmentManager;
            EnchantmentProperties = new ObservableCollection<BasicProperty>(Equipment.EnchantmentProperties);

            EnchantCommand = new DelegateCommand(Enchant);
        }

        [Obsolete]
        public EquipmentDetailViewModel()
        {
            Equipment = new BasicLance();
        }

        #region Private methods

        private void Enchant()
        {
            _enchantmentManager.Enchant(Equipment);
            EnchantmentProperties = new ObservableCollection<BasicProperty>(Equipment.EnchantmentProperties);
            OnPropertyChanged(nameof(EnchantmentProperties));
            OnPropertyChanged(nameof(EnchantmentLevel));
        }

        #endregion

        #region Fields

        private readonly IEnchantmentManager _enchantmentManager;

        #endregion
    }
}