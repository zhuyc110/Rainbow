using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    public abstract class SkillBase : BindableBase, ISkill
    {
        #region Properties

        public string Content { get; protected set; }

        public string IconResource { get; protected set; }

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

        public int LevelRequirement { get; protected set; }

        public string Name { get; protected set; }

        #endregion

        #region Fields

        private bool _isChecked;
        private bool _isVisible;

        #endregion
    }
}