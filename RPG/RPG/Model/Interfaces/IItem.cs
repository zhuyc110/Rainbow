namespace RPG.Model.Interfaces
{
    public interface IItem
    {
        long Id { get; }

        string ItemName { get; set; }

        string Content { get; }

        Rarity Rarity { get; }

        int Worth { get; }

        int Amount { get; }

        string IconResource { get; set; }
    }
}