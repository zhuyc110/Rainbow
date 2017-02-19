using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    [Export(typeof(ISkillManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillManager : ISkillManager
    {
        #region Properties

        public ObservableCollection<ISkill> Skills { get; }

        #endregion

        [ImportingConstructor]
        public SkillManager([ImportMany]IEnumerable<ISkill> skills, IIOService ioService)
        {
            var skillList = skills.ToList();
            _ioService = ioService;

            foreach (var skill in skillList)
            {
                var skillImp = skill as INotifyPropertyChanged;
                if (skillImp != null)
                    skillImp.PropertyChanged += SkillPropertyChanged;
            }

            Skills = new ObservableCollection<ISkill>(skillList);
        }

        private void SkillPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ISkill.IsChecked))
                return;

            if (Skills.Count(x => x.IsChecked) <= 3)
                return;

            _ioService.ShowMessage("提示", "最多只能同时装备三个技能");
            var skill = sender as ISkill;
            if (skill != null)
                skill.IsChecked = false;
        }

        #region Fields

        private readonly IIOService _ioService;

        #endregion
    }
}