using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using RPG.Model.Interfaces;

namespace RPG.Model.Equipment
{
    [Export(typeof(IEquipmentManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentManager : IEquipmentManager
    {
        public event EventHandler<EquipmentChangedArgs> OnEquipmentChanged;

        public IEnumerable<EquipmentBase> Equipments { get; }

        public EquipmentBase this[EquipmentPart index]
        {
            get
            {
                var result = Equipments.FirstOrDefault(x => x.IsEquiped && x.Part == index);
                if (result == null)
                {
                    return new DefaultEquipment(index);
                }
                return result;
            }
        }

        [ImportingConstructor]
        public EquipmentManager([ImportMany] IEnumerable<EquipmentBase> equipments)
        {
            var equipmentBases = equipments.ToList();
            foreach (var equipment in equipmentBases)
            {
                equipment.PropertyChanged += EquipmentPropertyChanged;
            }
            Equipments = equipmentBases;
        }

        #region Private methods

        private void EquipmentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(EquipmentBase.IsEquiped))
            {
                return;
            }

            var equipment = sender as EquipmentBase;
            if (equipment == null)
            {
                return;
            }

            if (!equipment.IsEquiped)
            {
                var handler = OnEquipmentChanged;
                handler?.Invoke(null, new EquipmentChangedArgs(equipment, null));
            }
            else
            {
                var handler = OnEquipmentChanged;
                handler?.Invoke(null, new EquipmentChangedArgs(null, equipment));
            }
        }

        #endregion
    }
}