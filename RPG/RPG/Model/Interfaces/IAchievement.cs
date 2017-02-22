using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Achivements;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IAchievement))]
    public interface IAchievement : IAchievementExtract
    {
        #region Properties

        bool Achived { get; }
        IEnumerable<AchivementPropertyBase> AchivementProperties { get; }
        string Content { get; }
        IEnumerable<IBattleProperty> Enhancements { get; }
        string IconResource { get; }

        #endregion
    }
}