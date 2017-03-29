using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Model.UserProperties;

namespace RPG.Model.Equipment
{
    [Serializable]
    public class EquipmentExtract
    {
        public string ItemName { get; set; }

        public bool IsEquiped { get; set; }

        public List<BasicProperty> EnchantmentProperties { get; set; }

        public EquipmentExtract()
        {
            ItemName = string.Empty;
            EnchantmentProperties = new List<BasicProperty>();
        }

        public EquipmentExtract(EquipmentBase equipment)
        {
            ItemName = equipment.ItemName;
            IsEquiped = equipment.IsEquiped;
            EnchantmentProperties = equipment.EnchantmentProperties.ToList();
        }
    }
}