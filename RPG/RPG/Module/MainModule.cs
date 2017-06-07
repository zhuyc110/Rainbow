using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using RPG.Infrastructure;
using RPG.View;
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
            _regionManager.RegisterViewWithRegion(Constants.HEADER_REGION, typeof(HeaderView));

            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(MainPage));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(AchievementsView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(SkillsView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(BackpackView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(ItemsView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(EquipmentView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(CharacterView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(AdventureView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(MonstersView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(BattleView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(BuyGemView));
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(BonusView)); 
            _regionManager.RegisterViewWithRegion(Constants.MAIN_REGION, typeof(DuplicationsView));

            _regionManager.RegisterViewWithRegion(Constants.NAVIGATION_REGION, typeof(NavigationView));
        }

        #endregion

        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion
    }
}