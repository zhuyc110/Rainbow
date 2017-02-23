﻿using System;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    [Serializable]
    public class AchievementExtract : IAchievementExtract
    {
        #region Properties

        public int Current { get; set; }
        public string Name { get; set; }

        #endregion

        public AchievementExtract(string name, int current)
        {
            Name = name;
            Current = current;
        }

        public AchievementExtract()
        {
            Name = string.Empty;
            Current = 0;
        }
    }
}