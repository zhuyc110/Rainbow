using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using log4net;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.Model.Bonus
{
    [Export(typeof(IBonusManager))]
    [Export(typeof(ISavableData))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BonusManager : IBonusManager, ISavableData
    {
        public IEnumerable<BonusEntity> BonusEntities { get; }

        [ImportingConstructor]
        public BonusManager(IItemManager itemManager, IUserState userState)
        {
            _itemManager = itemManager;
            _userState = userState;
            BonusEntities = new List<BonusEntity>
            {
                new BonusEntity(100, new List<IItem> {_itemManager.CreateItem("翡翠")}, userState),
                new BonusEntity(1000, new List<IItem> {_itemManager.CreateItem("翡翠", 100)}, userState)
            };
            RecoverBonus();
        }

        #region IBonusManager Members

        public void GetBonus(BonusEntity bonus)
        {
            foreach (var bonusItem in bonus.BonusItems)
            {
                if (bonusItem != null)
                {
                    _itemManager.AddItem((ItemBase) bonusItem);
                }
            }
        }

        #endregion

        #region ISavableData Members

        public void SaveData()
        {
            Log.Debug("...Saving bonus...");
            _userState.BonusEntities = BonusEntities.ToList();
        }

        #endregion

        #region Private methods

        private void RecoverBonus()
        {
            foreach (var bonus in _userState.BonusEntities)
            {
                var bonusInList = BonusEntities.FirstOrDefault(x => x.RequiredGem == bonus.RequiredGem);
                if (bonusInList == null)
                {
                    Log.Error($"Can not find bonus requires {bonus.RequiredGem} gems.");
                    continue;
                }
                bonusInList.IsGotten = bonus.IsGotten;
            }
        }

        #endregion

        #region Fields

        private readonly IItemManager _itemManager;
        private readonly IUserState _userState;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}