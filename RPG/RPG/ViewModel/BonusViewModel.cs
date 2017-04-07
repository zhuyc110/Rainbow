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
using RPG.Model.Bonus;
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
        public BonusViewModel(IItemManager itemManager, IEquipmentManager equipmentManager, IUserState userState, IBonusManager bonusManager)
        {
            _itemManager = itemManager;
            _equipmentManager = equipmentManager;
            _bonusManager = bonusManager;

            BonusEntities = new ObservableCollection<BonusEntity>(_bonusManager.BonusEntities);

            GetBonusCommand = new DelegateCommand<BonusEntity>(GetBonus);
        }

        [Obsolete]
        public BonusViewModel()
        {
            BonusEntities = new ObservableCollection<BonusEntity>
            {
                new BonusEntity(100, new List<IItem> {new ItemManager().CreateItem("翡翠")}, new UserState())
            };
        }

        #region Private methods

        private void GetBonus(BonusEntity bonus)
        {
            foreach (var bonusItem in bonus.BonusItems)
            {
                if (bonusItem != null)
                {
                    _itemManager.AddItem((ItemBase) bonusItem);
                    continue;
                }

                Log.Warn($"Can not find item: {bonusItem}");
            }

            _bonusManager.BonusEntities.Single(x => x.RequiredGem == bonus.RequiredGem).IsGotten = true;
        }

        #endregion

        #region Fields

        private readonly IItemManager _itemManager;
        private readonly IEquipmentManager _equipmentManager;
        private readonly IBonusManager _bonusManager;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}