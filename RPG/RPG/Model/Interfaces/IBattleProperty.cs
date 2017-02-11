namespace RPG.Model.Interfaces
{
    public interface IBattleProperty
    {
        #region Properties

        int AbsoluteEnhancement { get; set; }

        int Basic { get; set; }

        int FinalValue { get; set; }
        string Name { get; }

        double RelativeEnhancement { get; set; }

        #endregion
    }
}