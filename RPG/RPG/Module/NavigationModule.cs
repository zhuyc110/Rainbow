using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;

namespace RPG.Module
{
    [ModuleExport(typeof(NavigationModule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class NavigationModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public NavigationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(NavigationModule), typeof(NavigationView));
        }
    }
}