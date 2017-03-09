using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    public abstract class SkillBase : BindableBase, ISkill
    {
        public SkillEffect SkillEffect { get; private set; }

        public int AttackFrequency { get; protected set; }

        public double DamageRatePerAttack { get; protected set; }

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

        public double AppearRate
        {
            get { return _appearRate; }
            set { SetProperty(ref _appearRate, value); }
        }

        protected SkillBase(string name, string content, string iconResource, int levelRequirement, double appearRate, SkillEffect skillEffect = SkillEffect.Damage)
        {
            Name = name;
            Content = content;
            IconResource = iconResource;
            LevelRequirement = levelRequirement;
            AppearRate = appearRate;

            AttackFrequency = 1;
            DamageRatePerAttack = 1;
        }

        #region Fields

        private bool _isChecked;
        private bool _isVisible;
        private double _appearRate;

        #endregion
    }
}