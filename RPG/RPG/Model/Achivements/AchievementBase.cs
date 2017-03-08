using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public abstract class AchievementBase : BindableBase, IAchievement
    {
        #region Properties

        public bool Achived => Current >= Condition;

        public IEnumerable<AchivementPropertyBase> AchivementProperties { get; protected set; }
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

        #endregion

        protected AchievementBase(IEnumerable<IBattleProperty> properties, string name, string content, IReadOnlyCollection<AchivementPropertyBase> achivementProperties, int condition, string iconResource)
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
        public abstract void HandleEvent();

        #endregion

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

        #region Fields

        private int _current;

        #endregion
    }
}