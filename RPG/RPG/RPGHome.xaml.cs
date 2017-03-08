using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using log4net;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG
{
    /// <summary>
    ///     RPGHome.xaml 的交互逻辑
    /// </summary>
    [Export(typeof (RpgHome))]
    public partial class RpgHome
    {
        [Import]
        private IXmlSerializer XmlSerializer { get; set; }

        [Import]
        private IUserState UserState { get; set; }

        [Import]
        private IItemManager ItemManager { get; set; }

        [ImportMany]
        private IEnumerable<ISavableData> SavableDatas { get; set; }

        [ImportingConstructor]
        public RpgHome()
        {
            InitializeComponent();
        }

        #region Protected methods

        protected override void OnClosing(CancelEventArgs e)
        {
            Log.Info("Start serializing UserData...");
            foreach (var savableData in SavableDatas)
            {
                savableData.SaveData();
            }
            XmlSerializer.Serialize((ItemManager) ItemManager, "ItemData.dat");
            XmlSerializer.Serialize((UserState) UserState, "UserData.dat");
            Log.Info("UserData serializing finished.");

            base.OnClosing(e);
        }

        #endregion

        #region Fields

        private static readonly ILog Log = LogManager.GetLogger(typeof (RpgHome));

        #endregion
    }
}