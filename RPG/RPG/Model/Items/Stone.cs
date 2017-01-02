namespace RPG.Model.Items
{
    public class Stone : ItemBase
    {
        public Stone()
        {
            Amount = 1;
            Content = "这是一块石头";
            Name = "石头";
            Rarity = Rarity.Normal;
            Worth = 200;
            IconResource = "BTNGolemStormBolt";
        }
    }
}