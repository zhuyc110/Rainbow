using System;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Export(typeof(IUserState))]
    public class UserState : BindableBase, IUserState
    {
        #region Fields

        private long _experience;
        private long _gem;
        private long _gold;
        private int _level;
        private string _title;

        #endregion

        [ImportingConstructor]
        public UserState()
        {
            Level = 1;
            Gold = 1000;
            Gem = 100;
            UserName = "Sky - Han";
            Title = "一个称号";
            Experience = 1499;
        }

        #region IUserState Members

        public long Experience
        {
            get { return _experience; }
            set
            {
                SetProperty(ref _experience, value);
                CalculateLevel(Experience);
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

        public int Level
        {
            get { return _level; }
            set
            {
                if (SetProperty(ref _level, value))
                {
                    var handle = LevelUp;
                    handle?.Invoke(null,null);
                }
            }
        }

        public event EventHandler LevelUp;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string UserName { get; set; }

        #endregion

        private void CalculateLevel(long exp)
        {
            var expLevel = exp / 1000.0;
            Level = Math.Max((int) Math.Log(expLevel, 1.5), 0) + 1;
        }
    }
}