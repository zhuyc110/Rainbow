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
        [ImportMany]
        public IEnumerable<ISkill> Skills { get; set; }

        [ImportingConstructor]
        public SkillsViewModel()
        {
        }
    }
}
