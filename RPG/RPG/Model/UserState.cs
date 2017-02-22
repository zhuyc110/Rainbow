using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;
using RPG.Model.Achivements;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Serializable]
    public class UserState : BindableBase, IUserState
    {
        public event EventHandler ExpChanged;

        public event EventHandler LevelUp;

        #region Properties

        [XmlArray]
        public List<AchievementExtract> Achievements { get; }

        public List<string> CheckedSkills { get; set; }

        public int Level
        {
            get { return _level; }
            set
            {
                if (SetProperty(ref _level, value))
                {
                    var handle = LevelUp;
                    handle?.Invoke(null, null);
                }
            }
        }

        public long Experience
        {
            get { return _experience; }
            set
            {
                if (SetProperty(ref _experience, value))
                {
                    CalculateLevel();
                    var handle = ExpChanged;
                    handle?.Invoke(null, null);
                }
            }
        }

        public long Gem
        {
            get { return _gem; }
            set { SetProperty(ref _gem, value); }
        }

        public long Gold
        {
            get { return _gold; }
            set { SetProperty(ref _gold, value); }
        }

        [XmlIgnore]
        public IItemManager ItemManager { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string UserName { get; set; }

        #endregion

        public UserState()
        {
            Level = 1;
            Gold = 0;
            Gem = 0;
            UserName = "Sky - Han";
            Title = "";
            Experience = 0;
            CheckedSkills = new List<string>();
        }

        private void CalculateLevel()
        {
            var expRequiredOfCurrentLevel = 500 * (long) Math.Pow(1.5, Level - 1);

            if (Experience >= expRequiredOfCurrentLevel)
            {
                Level += 1;
                Experience = Experience - expRequiredOfCurrentLevel;
            }
        }

        #region Fields

        private long _experience;
        private long _gem;
        private long _gold;
        private int _level;
        private string _title;

        #endregion
    }
}