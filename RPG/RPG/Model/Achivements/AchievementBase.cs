using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<IBattleProperty> Enhancements { get; protected set; }

        public string IconResource { get; protected set; }

        public string Name { get; protected set; }

        protected AchievementBase(IEnumerable<IBattleProperty> properties, string name, string content, IReadOnlyCollection<BasicProperty> achivementProperties,
            int condition, string iconResource)
        {
            Enhancements = properties;
            Name = name;
            Content = content;
            AchivementProperties = achivementProperties;
            Condition = condition;
            IconResource = iconResource;

            if (Achived)
                ComposeProperty();
        }

        #region IAchievement Members

        public abstract bool CanHandleEvent<T>(T args);

        public void ComposeProperty()
        {
            if (Enhancements == null)
                return;
            foreach (var achivementProperty in AchivementProperties)
            {
                var property = Enhancements.FirstOrDefault(x => x.Name == achivementProperty.Name);
                if (property == null)
                    continue;
                property.AbsoluteEnhancement += achivementProperty.AbsoluteEnhancement;
                property.RelativeEnhancement *= 1 + achivementProperty.RelativeEnhancement;
            }
        }

        public abstract void HandleEvent();

        #endregion

        #region Fields

        private int _current;

        #endregion
    }
}