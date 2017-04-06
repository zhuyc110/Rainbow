using System.ComponentModel;
using System.ComponentModel.Composition;
using log4net;
using RPG.Infrastructure.Interfaces;

namespace RPG
{
    /// <summary>
    ///     RPGHome.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(RpgHome))]
    public partial class RpgHome
    {
        [ImportingConstructor]
        public RpgHome(ISavableDataManager savableDataManager)
        {
            _savableDataManager = savableDataManager;
            InitializeComponent();
        }

        #region Protected methods

        protected override void OnClosing(CancelEventArgs e)
        {
            Log.Info("Start serializing UserData...");
            _savableDataManager.SaveData();
            Log.Info("UserData serializing finished.");

            base.OnClosing(e);
        }

        #endregion

        #region Fields

        private readonly ISavableDataManager _savableDataManager;

        private static readonly ILog Log = LogManager.GetLogger(typeof(RpgHome));

        #endregion
    }
}