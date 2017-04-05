﻿using System.Collections.Generic;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Achivements
{
    public abstract class AchievementBase : BindableBase, IAchievement
    {
        public bool Achived => Current >= Condition;

        public IEnumerable<BasicProperty> AchivementProperties { get; protected set; }
        public int Condition { get; protected set; }

        public string Content { get; protected set; }

        public int Current
        {
            get { return _current; }
            set
            {
                SetProperty(ref _current, value);
                OnPropertyChanged(nameof(Achived));
            }
        }

        public string IconResource { get; protected set; }

        public string Name { get; protected set; }

        protected AchievementBase(string name, string content, IReadOnlyCollection<BasicProperty> achivementProperties,
            int condition, string iconResource)
        {
            Name = name;
            Content = content;
            AchivementProperties = achivementProperties;
            Condition = condition;
            IconResource = iconResource;
        }

        #region IAchievement Members

        public abstract bool CanHandleEvent<T>(T args);

        public abstract void HandleEvent();

        #endregion

        #region Fields

        private int _current;

        #endregion
    }
}