using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;
using System.ComponentModel.Composition;

namespace RPG.Module
{
    [ModuleExport(typeof(ItemsModule))]
    public class ItemsModule : IModule
    {
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public ItemsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(ItemsModule), typeof(ItemsView));
        }
    }
}