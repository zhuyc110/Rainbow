using Prism.Mvvm;
using RPG.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.ViewModel
{
    [Export(nameof(SkillsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillsViewModel : BindableBase
    {
        public ObservableCollection<ISkill> Skills { get; set; }

        [ImportingConstructor]
        public SkillsViewModel([ImportMany]IEnumerable<ISkill> skills)
        {
            Skills = new ObservableCollection<ISkill>();
            foreach (var skill in skills.OrderBy(x=>x.LevelRequirement))
            {
                Skills.Add(skill);
            }
        }
    }
}
