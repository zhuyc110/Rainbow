using System;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public class AchievementEventArgs : EventArgs
    {
        #region Properties

        public IAchievement Achievement { get; }

        #endregion

        public AchievementEventArgs(IAchievement achievement)
        {
            Achievement = achievement;
        }
    }
}