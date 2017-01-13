using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;

namespace RPG.Module
{
    [ModuleExport(typeof(UserEquipmentModule))]
    public class UserEquipmentModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public UserEquipmentModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(UserEquipmentModule), typeof(UserEquipmentView));
        }
    }
}