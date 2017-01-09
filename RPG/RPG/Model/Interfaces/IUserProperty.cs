namespace RPG.Model.Interfaces
{
    public interface IUserProperty
    {
        string Name { get; }

        int Basic { get; set; }

        int AbsoluteEnhancement { get; set; }

        double RelativeEnhancement { get; set; }

        int FinalValue { get; }
    }
}