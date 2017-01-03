namespace RPG.Model.Items
{
    public class Gemstone : ItemBase
    {
        public Gemstone()
        {
            Amount = 1;
            Content = "这是一块宝石";
            Name = "宝石";
            Rarity = Rarity.Rare;
            Worth = 2000;
            IconResource = "BTNGem";
        }
    }
}