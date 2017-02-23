using System;
using System.Collections.ObjectModel;
using RPG.Model.Achivements;

namespace RPG.Model.Interfaces
{
    public interface IAchievementManager
    {
        event EventHandler<AchievementEventArgs> OnAchievementGet;

        #region Properties

        ObservableCollection<IAchievement> Achievements { get; set; }

        #endregion

        void SaveData();
    }
}