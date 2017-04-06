using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
using log4net;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(ISavableDataManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SavableDataManager : ISavableDataManager
    {
        [ImportMany]
        public IEnumerable<ISavableData> SavableDatas { get; private set; }

        [ImportingConstructor]
        public SavableDataManager(IXmlSerializer xmlSerializer, IItemManager itemManager, IUserState userState, IIOService ioService)
        {
            _xmlSerializer = xmlSerializer;
            _itemManager = itemManager;
            _userState = userState;
            _ioService = ioService;
        }

        #region ISavableDataManager Members

        public void SaveData()
        {
            try
            {
                foreach (var savableData in SavableDatas)
                {
                    savableData.SaveData();
                }

                _xmlSerializer.Serialize((ItemManager) _itemManager, "ItemData.dat");
                _xmlSerializer.Serialize((UserState) _userState, "UserData.dat");
            }
            catch (Exception exception)
            {
                Log.Error("Can not save user data!", exception);
                _ioService.ShowMessage("错误", "无法保存用户数据");
            }
        }

        #endregion

        #region Fields

        private readonly IXmlSerializer _xmlSerializer;
        private readonly IItemManager _itemManager;
        private readonly IUserState _userState;
        private readonly IIOService _ioService;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}