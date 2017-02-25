using System;
using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public class AchievementEventArgs : EventArgs
    {
        #region Properties

        public IEnumerable<IAchievement> Achievements { get; }

        #endregion

        public AchievementEventArgs(IEnumerable<IAchievement> achievements)
        {
            Achievements = achievements;
        }
    }
}