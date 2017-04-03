using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using log4net;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.ViewModel
{
    [Export(typeof(BonusViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BonusViewModel : BindableBase
    {
        public ObservableCollection<BonusEntity> BonusEntities { get; private set; }

        public ICommand GetBonusCommand { get; private set; }

        [ImportingConstructor]
        public BonusViewModel(IItemManager itemManager, IEquipmentManager equipmentManager, IUserState userState)
        {
            _itemManager = itemManager;
            _equipmentManager = equipmentManager;
            _userState = userState;

            BonusEntities = new ObservableCollection<BonusEntity>
            {
                new BonusEntity(100, new List<IItem> {_itemManager.Items.Single(x => x.ItemName == "翡翠")}, _userState)
            };

            GetBonusCommand = new DelegateCommand<BonusEntity>(GetBonus);
        }

        [Obsolete]
        public BonusViewModel()
        {
            BonusEntities = new ObservableCollection<BonusEntity>
            {
                new BonusEntity(100, new List<IItem> {new ItemManager().Items.Single(x => x.ItemName == "翡翠")}, new UserState())
            };
        }

        #region Private methods

        private void GetBonus(BonusEntity bonus)
        {
            foreach (var bonusItem in bonus.BonusItems)
            {
                IItem item = _itemManager.Items.FirstOrDefault(x => x.ItemName == bonusItem.ItemName);
                if (item != null)
                {
                    ((ItemBase) item).Amount += 1;
                    continue;
                }

                item = _equipmentManager.Equipments.FirstOrDefault(x => x.ItemName == bonusItem.ItemName);

                if (item != null)
                {
                    ((EquipmentBase) item).Amount += 1;
                    continue;
                }

                Log.Warn($"Can not find item: {bonusItem.ItemName}");
            }
        }

        #endregion

        #region Fields

        private readonly IItemManager _itemManager;
        private readonly IEquipmentManager _equipmentManager;
        private readonly IUserState _userState;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}