namespace RPG.Model.Equipment
{
    public class DefaultEquipment : EquipmentBase
    {
        public DefaultEquipment(EquipmentPart part)
        {
            Rarity = Rarity.Normal;
            Part = part;
        }
    }
}