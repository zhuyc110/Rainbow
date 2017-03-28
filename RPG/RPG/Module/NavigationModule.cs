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
        [ImportingConstructor]
        public NavigationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        #region IModule Members

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(NavigationModule), typeof(NavigationView));
        }

        #endregion

        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion
    }
}