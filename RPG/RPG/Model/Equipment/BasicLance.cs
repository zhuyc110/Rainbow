using System.ComponentModel.Composition;

namespace RPG.Model.Equipment
{
    //[Export(nameof(BasicLance), typeof(EquipmentBase))]
    public class BasicLance : EquipmentBase
    {
        //[ImportingConstructor]
        public BasicLance()
        {
            Content = "基础的长枪";
            ItemName = "长枪";
            Rarity = Rarity.Normal;
            Worth = 2000;
            IconResource = "INV_Spear_05";
            Part = EquipmentPart.Weapon;
        }
    }
}