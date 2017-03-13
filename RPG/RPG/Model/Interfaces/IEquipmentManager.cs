using System;
using System.Collections.Generic;
using RPG.Model.Equipment;

namespace RPG.Model.Interfaces
{
    public interface IEquipmentManager
    {
        event EventHandler<EquipmentChangedArgs> OnEquipmentChanged;

        IEnumerable<EquipmentBase> Equipments { get; }
    }
}