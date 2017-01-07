namespace RPG.Model.Equipment
{
    public class BasicLance : EquipmentBase
    {
        public BasicLance()
        {
            Content = "基础的长枪";
            ItemName = "长枪";
            Rarity = Rarity.Normal;
            Worth = 2000;
            IconResource = "BTNSteelRanged";
            Part = EquipmentPart.Weapon;
        }
    }
}