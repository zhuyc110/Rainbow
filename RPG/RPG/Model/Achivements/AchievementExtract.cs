using System;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    [Serializable]
    public class AchievementExtract : IAchievementExtract
    {
        #region Properties

        public int Condition { get; }
        public int Current { get; }
        public string Name { get; }

        #endregion

        public AchievementExtract(string name, int condition, int current)
        {
            Name = name;
            Condition = condition;
            Current = current;
        }

        public AchievementExtract()
        {
            Name = string.Empty;
            Condition = 0;
            Current = 0;
        }
    }
}