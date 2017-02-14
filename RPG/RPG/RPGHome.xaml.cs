using System.ComponentModel;
using System.ComponentModel.Composition;
using log4net;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG
{
    /// <summary>
    ///     RPGHome.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(RpgHome))]
    public partial class RpgHome
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RpgHome));

        [Import]
        private IXmlSerializer XmlSerializer { get; set; }

        [Import]
        private IUserState UserState { get; set; }

        [ImportingConstructor]
        public RpgHome()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Log.Info("Start serializing UserData...");
            XmlSerializer.Serialize((UserState)UserState, "UserData.dat");
            Log.Info("UserData serializing finished.");
            base.OnClosing(e);
        }
    }
}