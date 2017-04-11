using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(EquipmentViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentViewModel : BindableBase
    {
        public IEquipmentManager EquipmentManager { get; }

        public ICommand ShowDetailCommand { get; }

        [ImportingConstructor]
        public EquipmentViewModel(IEquipmentManager equipmentManager, IIOService ioService, IEnchantmentManager enchantmentManager)
        {
            EquipmentManager = equipmentManager;
            _ioService = ioService;
            _enchantmentManager = enchantmentManager;
            ShowDetailCommand = new DelegateCommand<EquipmentBase>(ShowDetail);
        }

        [Obsolete("This is ONLY used for Design view")]
        public EquipmentViewModel()
        {
            EquipmentManager = new EquipmentManager(new List<EquipmentBase> {new BasicLance(), new BasicLance()}, new UserState());
        }

        #region Private methods

        private void ShowDetail(EquipmentBase equipment)
        {
            var detailVm = new EquipmentDetailViewModel(equipment, _enchantmentManager);
            _ioService.ShowDialog(detailVm);
        }

        #endregion

        #region Fields

        private readonly IIOService _ioService;
        private readonly IEnchantmentManager _enchantmentManager;

        #endregion
    }
}