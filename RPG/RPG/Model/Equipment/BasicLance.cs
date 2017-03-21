using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.UserProperties;

namespace RPG.Model.Equipment
{
    [Export(typeof(EquipmentBase))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BasicLance : EquipmentBase
    {
        [ImportingConstructor]
        public BasicLance()
            : base(new List<BasicProperty>
            {
                new BasicProperty("攻击", 2, 0)
            })
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