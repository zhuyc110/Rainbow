using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    public abstract class AchievementBase : BindableBase, IAchievement
    {
        private int _current;
        
        public IEnumerable<IUserProperty> Enhancements { get; protected set; }

        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public IEnumerable<AchivementPropertyBase> AchivementProperties { get; protected set; }

        public bool Achived => Current == Condition;
        public int Condition { get; protected set; }

        public int Current
        {
            get { return _current; }
            set
            {
                SetProperty(ref _current, value);
                OnPropertyChanged(nameof(Achived));
            }
        }

        protected void ComposeProperty()
        {
            if(Enhancements == null)
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
    }
}