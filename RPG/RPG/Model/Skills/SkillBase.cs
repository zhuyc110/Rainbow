using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    public abstract class SkillBase : BindableBase, ISkill
    {
        private bool _isChecked;
        public string Content { get; protected set; }

        public string IconResource { get; protected set; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        public int LevelRequirement { get; protected set; }

        public string Name { get; protected set; }
    }
}