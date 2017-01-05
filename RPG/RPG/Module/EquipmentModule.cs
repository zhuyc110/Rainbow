using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;
using System.ComponentModel.Composition;

namespace RPG.Module
{
    [ModuleExport(typeof(EquipmentModule))]
    public class EquipmentModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public EquipmentModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(EquipmentModule), typeof(EquipmentView));
        }
    }
}