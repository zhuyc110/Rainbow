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
        [ImportingConstructor]
        public HeaderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        #region IModule Members

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(nameof(HeaderModule), typeof(HeaderView));
        }

        #endregion

        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion
    }
}