using Prism.Mvvm;
using RPG.Model.Interfaces;
using System.Windows.Media;

namespace RPG.Model.Skills
{
    public abstract class AbstractSkill : BindableBase, ISkill
    {
        public string Content { get; protected set; }

        public ImageSource Icon { get; protected set; }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }

        public int LevelRequirement { get; protected set; }

        public string Name { get; protected set; }

        private bool _isChecked = false;
    }
}