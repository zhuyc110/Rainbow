using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Model.Items;
using RPG.Model.Skills;

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

        [Import]
        private IItemManager ItemManager { get; set; }

        [Import]
        private ISkillManager SkillManager { get; set; }

        [ImportingConstructor]
        public RpgHome()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Log.Info("Start serializing UserData...");
            SkillManager.SaveSkillStatus();
            XmlSerializer.Serialize((ItemManager)ItemManager, "ItemData.dat");
            XmlSerializer.Serialize((UserState)UserState, "UserData.dat");
            Log.Info("UserData serializing finished.");

            base.OnClosing(e);
        }
    }
}