using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.UserProperties;

namespace RPG.Model.Equipment
{
    [Export(typeof(EquipmentBase))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UltimateChestPlate : EquipmentBase
    {
        [ImportingConstructor]
        public UltimateChestPlate()
            : base(new List<BasicProperty>
            {
                new BasicProperty("生命", 20, 0)
            })
        {
            Content = "终极的胸甲";
            ItemName = "黄金甲";
            Rarity = Rarity.Legend;
            Worth = 20000;
            IconResource = "INV_Chest_Plate03";
            Part = EquipmentPart.Breastplate;
        }
    }
}