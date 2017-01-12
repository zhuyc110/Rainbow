using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Achivements;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IAchievement))]
    public interface IAchievement
    {
        string Name { get; }
        string Content { get; }
        string IconResource { get; }
        bool Achived { get; }
        int Condition { get; }
        int Current { get; }
        IEnumerable<IUserProperty> Enhancements { get; }
        IEnumerable<AchivementPropertyBase> AchivementProperties { get; }
    }
}