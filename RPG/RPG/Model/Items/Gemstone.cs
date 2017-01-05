namespace RPG.Model.Items
{
    public class Gemstone : ItemBase
    {
        public Gemstone()
        {
            Amount = 1;
            Content = "这是一块宝石";
            ItemName = "宝石";
            Rarity = Rarity.Rare;
            Worth = 2000;
            IconResource = "BTNGem";
        }
    }
}