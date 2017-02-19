using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(SkillsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillsViewModel : BindableBase
    {
        #region Properties
        
        public ISkillManager SkillManager { get; }

        #endregion

        [ImportingConstructor]
        public SkillsViewModel(ISkillManager skillManager)
        {
            SkillManager = skillManager;
        }
    }
}