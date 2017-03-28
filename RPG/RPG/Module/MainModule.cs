using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.View.MainView;

namespace RPG.Module
{
    [ModuleExport(typeof(MainModule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainModule : IModule
    {
        [ImportingConstructor]
        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        #region IModule Members

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(MainPage));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(AchievementsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(SkillsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(BackpackView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(ItemsView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(EquipmentView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(CharacterView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(AdventureView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(MonstersView));
            _regionManager.RegisterViewWithRegion(nameof(MainModule), typeof(BattleView));
        }

        #endregion

        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion
    }
}