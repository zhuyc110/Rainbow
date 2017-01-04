using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using RPG.Model.Skills;

namespace RPG.ViewModel
{
    [Export(nameof(SkillsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillsViewModel : BindableBase
    {
        private readonly IIOService _ioService;

        [ImportingConstructor]
        public SkillsViewModel([ImportMany] IEnumerable<ISkill> skills, IIOService ioService)
        {
            _ioService = ioService;

            Skills = new ObservableCollection<ISkill>();
            foreach (var skill in skills.OrderBy(x => x.LevelRequirement))
            {
                var notifyPropertyChanged = skill as INotifyPropertyChanged;
                if (notifyPropertyChanged != null)
                    notifyPropertyChanged.PropertyChanged += SkillPropertyChanged;
                Skills.Add(skill);
            }
        }

        [Obsolete("This is ONLY used for Design view")]
        public SkillsViewModel()
        {
            Skills = new ObservableCollection<ISkill>
            {
                new Fireball()
            };
        }

        public ObservableCollection<ISkill> Skills { get; }

        private void SkillPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ISkill.IsChecked))
            {
                return;
            }

            if (Skills.Count(x => x.IsChecked) <= 3)
            {
                return;
            }

            _ioService.ShowDialog("提示", "最多只能同时装备三个技能");
            var skill = sender as ISkill;
            if (skill != null)
            {
                skill.IsChecked = false;
            }
        }
    }
}