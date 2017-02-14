using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.Model
{
    [Serializable]
    public class UserState : BindableBase, IUserState
    {
        #region Fields

        private long _experience;
        private long _gem;
        private long _gold;
        private int _level;
        private string _title;

        #endregion

        public UserState()
        {
            Level = 1;
            Gold = 0;
            Gem = 0;
            UserName = "Sky - Han";
            Title = "";
            Experience = 0;
            Items = new List<ItemBase>();
        }

        #region IUserState Members

        public event EventHandler ExpChanged;

        public event EventHandler LevelUp;

        public void AddItem(ItemBase newItem)
        {
            var item = Items.FirstOrDefault(x => x.ItemName == newItem.ItemName);
            if (item == null)
                Items.Add(newItem);
            else
                item.Amount += newItem.Amount;
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
        public IList<ItemBase> Items { get; set; }

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

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string UserName { get; set; }

        #endregion

        private void CalculateLevel()
        {
            var expRequiredOfCurrentLevel = 500 * (long) Math.Pow(1.5, Level - 1);

            if (Experience >= expRequiredOfCurrentLevel)
            {
                Level += 1;
                Experience = Experience - expRequiredOfCurrentLevel;
            }
        }
    }
}