using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;

namespace RPG.Module
{
    [ModuleExport(typeof (SkillsModule))]
    public class SkillsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public SkillsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(SkillsModule), typeof (SkillsView));
        }
    }
}