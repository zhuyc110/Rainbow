using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Equipment;

namespace RPG.ViewModel
{
    [Export(typeof(EquipmentViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentViewModel : BindableBase
    {
        public ObservableCollection<EquipmentBase> Equipments { get; }

        public ICommand ShowDetailCommand { get; }

        [ImportingConstructor]
        public EquipmentViewModel([ImportMany] IEnumerable<EquipmentBase> equipments, IIOService ioService)
        {
            Equipments = new ObservableCollection<EquipmentBase>();
            _ioService = ioService;
            ShowDetailCommand = new DelegateCommand<EquipmentBase>(ShowDetail);

            foreach (var item in equipments.OrderBy(x => x.Rarity))
            {
                Equipments.Add(item);
            }
        }

        [Obsolete("This is ONLY used for Design view")]
        public EquipmentViewModel()
        {
            Equipments = new ObservableCollection<EquipmentBase>
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

        #region Private methods

        private void ShowDetail(EquipmentBase equipment)
        {
            var detailVm = new EquipmentDetailViewModel(equipment);
            _ioService.ShowViewModel(detailVm);
        }

        #endregion

        #region Fields

        private readonly IIOService _ioService;

        #endregion
    }
}