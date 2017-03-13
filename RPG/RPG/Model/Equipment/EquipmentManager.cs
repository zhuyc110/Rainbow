using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.Equipment
{
    [Export(typeof(IEquipmentManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentManager : IEquipmentManager
    {
        public event EventHandler<EquipmentChangedArgs> OnEquipmentChanged;

        public IEnumerable<EquipmentBase> Equipments { get; }
    }
}