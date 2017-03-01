using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    public abstract class SkillBase : BindableBase, ISkill
    {
        #region Properties

        public int AttackFrequency { get; protected set; }

        public double AttackRate { get; protected set; }

        public string Content { get; }

        public string IconResource { get; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        public int LevelRequirement { get; }

        public string Name { get; }

        public double Rate
        {
            get { return _rate; }
            set { SetProperty(ref _rate, value); }
        }

        #endregion

        protected SkillBase(string name, string content, string iconResource, int levelRequirement, double rate)
        {
            Name = name;
            Content = content;
            IconResource = iconResource;
            LevelRequirement = levelRequirement;
            Rate = rate;

            AttackFrequency = 1;
            AttackRate = 1;
        }

        #region Fields

        private bool _isChecked;
        private bool _isVisible;
        private double _rate;

        #endregion
    }
}