using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View;
using System.ComponentModel.Composition;

namespace RPG.Module
{
    [ModuleExport(typeof(MainModule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
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
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(AchievementsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(SkillsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(BackpackView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(ItemsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(EquipmentView)); 
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(UserEquipmentView));
        }
    }
}