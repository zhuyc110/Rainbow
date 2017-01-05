using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;
using System.ComponentModel.Composition;

namespace RPG.Module
{
    [ModuleExport(typeof(MainModule))]
    public class MainModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(MainPage));
        }
    }
}