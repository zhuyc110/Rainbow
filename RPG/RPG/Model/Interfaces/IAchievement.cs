using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Model.Achivements;
using RPG.Model.UserProperties;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IAchievement))]
    public interface IAchievement : IAchievementExtract
    {
        int Condition { get; }
        bool Achived { get; }
        IEnumerable<BasicProperty> AchivementProperties { get; }
        string Content { get; }
        string IconResource { get; }
        
        bool CanHandleEvent<T>(T args);
        void HandleEvent();
    }
}