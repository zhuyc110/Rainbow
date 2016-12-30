using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;
using System.ComponentModel.Composition;

namespace RPG.Module
{
    [ModuleExport(typeof(BackpackModule))]
    public class BackpackModule : IModule
    {
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public BackpackModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(BackpackModule), typeof(SkillsView));
        }
    }
}