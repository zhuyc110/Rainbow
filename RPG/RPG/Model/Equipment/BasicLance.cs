namespace RPG.Model.Equipment
{
    public class BasicLance : EquipmentBase
    {
        public BasicLance()
        {
            Content = "基础的矛";
            ItemName = "长矛";
            Rarity = Rarity.Normal;
            Worth = 2000;
            IconResource = "BTNSteelRanged";
        }
    }
}