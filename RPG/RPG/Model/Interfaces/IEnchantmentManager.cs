using System;
using RPG.Model.Equipment;

namespace RPG.Model.Interfaces
{
    public interface IEnchantmentManager
    {
        string Enchant(EquipmentBase equipment);

        string CalculateEnchantLevel(EquipmentBase equipment);

        int CalculateCost(EquipmentBase equipment);

        event EventHandler EquipedEquipmentEnchantmentChanged;
    }
}