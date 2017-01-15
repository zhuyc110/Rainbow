using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;

namespace RPG.Module
{
    [ModuleExport(typeof(HeaderModule))]
    public class HeaderModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public HeaderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(HeaderModule), typeof(HeaderView));
        }
    }
}