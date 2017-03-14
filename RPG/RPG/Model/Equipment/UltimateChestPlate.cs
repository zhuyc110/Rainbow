using System.ComponentModel.Composition;

namespace RPG.Model.Equipment
{
    //[Export(nameof(UltimateChestPlate), typeof(EquipmentBase))]
    public class UltimateChestPlate : EquipmentBase
    {
        //[ImportingConstructor]
        public UltimateChestPlate()
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