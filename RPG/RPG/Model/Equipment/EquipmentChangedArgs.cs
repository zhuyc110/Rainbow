using System;

namespace RPG.Model.Equipment
{
    public class EquipmentChangedArgs : EventArgs
    {
        public EquipmentBase OldEquipment { get; }

        public EquipmentBase NewEquipment { get; }

        public EquipmentChangedArgs(EquipmentBase oldEquipment, EquipmentBase newEquipment)
        {
            OldEquipment = oldEquipment;
            NewEquipment = newEquipment;
        }
    }
}