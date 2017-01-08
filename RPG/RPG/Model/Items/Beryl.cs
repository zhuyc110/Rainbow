namespace RPG.Model.Items
{
    public class Beryl : ItemBase
    {
        public Beryl()
        {
            Amount = 5;
            Content = "这是一块翡翠";
            ItemName = "翡翠";
            Rarity = Rarity.Rare;
            Worth = 2000;
            IconResource = "INV_Misc_Gem_Emerald_02";
        }
    }
}