using Prism.Mvvm;
using RPG.Model.Interfaces;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace RPG.Model.Skills
{
    [Export(nameof(HeavyStrike))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HeavyStrike : BindableBase, ISkill
    {
        public string Content => "对敌人造成150%伤害";

        public ImageSource Icon => null;

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

        public int LevelRequirement => 1;

        public string Name => "重击";

        private bool _isChecked = false;

        [ImportingConstructor]
        public HeavyStrike()
        {

        }
    }
}