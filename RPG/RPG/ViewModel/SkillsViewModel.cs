using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace RPG.ViewModel
{
    [Export(nameof(SkillsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillsViewModel : BindableBase
    {
        public ObservableCollection<ISkill> Skills { get; private set; }

        [ImportingConstructor]
        public SkillsViewModel([ImportMany]IEnumerable<ISkill> skills, IIOService ioService)
        {
            _ioService = ioService;

            Skills = new ObservableCollection<ISkill>();
            foreach (var skill in skills.OrderBy(x => x.LevelRequirement))
            {
                (skill as INotifyPropertyChanged).PropertyChanged += SkillPropertyChanged;
                Skills.Add(skill);
            }
        }

        [Obsolete("This is ONLY used for Design view")]
        public SkillsViewModel()
        {
            Skills = new ObservableCollection<ISkill>
            {
                new Model.Skills.Fireball()
            };
        }

        private void SkillPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ISkill.IsChecked))
            {
                return;
            }

            if (Skills.Where(x => x.IsChecked).Count() > 3)
            {
                _ioService.ShowDialog("提示", "最多只能同时装备三个技能");
                var skill = sender as ISkill;
                if (skill != null)
                {
                    skill.IsChecked = false;
                }
            }
        }

        private readonly IIOService _ioService;
    }
}