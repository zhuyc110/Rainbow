namespace RPG.Model.Interfaces
{
    public interface IAchievementExtract
    {
        #region Properties

        int Condition { get; }
        int Current { get; }
        string Name { get; }

        #endregion
    }
}