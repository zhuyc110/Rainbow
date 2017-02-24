using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Achivements;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IAchievement))]
    public interface IAchievement : IAchievementExtract
    {
        #region Properties

        int Condition { get; }
        bool Achived { get; }
        IEnumerable<AchivementPropertyBase> AchivementProperties { get; }
        string Content { get; }
        IEnumerable<IBattleProperty> Enhancements { get; }
        string IconResource { get; }

        #endregion

        bool CanHandleEvent<T>(T args);
        void HandleEvent();
    }
}