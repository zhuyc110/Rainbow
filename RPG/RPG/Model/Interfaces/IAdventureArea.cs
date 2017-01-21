namespace RPG.Model.Interfaces
{
    public interface IAdventureArea
    {
        string AreaName { get; }
        string IconResource { get; }
        int MinLevel { get; }
        int MaxLevel { get; }
    }
}