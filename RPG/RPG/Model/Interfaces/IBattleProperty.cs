using System.ComponentModel.Composition;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IBattleProperty))]
    public interface IBattleProperty
    {
        string Name { get; }

        int Basic { get; set; }

        int AbsoluteEnhancement { get; set; }

        double RelativeEnhancement { get; set; }

        int FinalValue { get; }
    }
}