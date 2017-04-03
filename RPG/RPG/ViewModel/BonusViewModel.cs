using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(BonusViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BonusViewModel : BindableBase
    {
        public ObservableCollection<BonusEntity> BonusEntities { get; set; }

        [ImportingConstructor]
        public BonusViewModel(IItemManager itemManager, IEquipmentManager equipmentManager)
        {
            _itemManager = itemManager;
            _equipmentManager = equipmentManager;

            BonusEntities = new ObservableCollection<BonusEntity>
            {
                new BonusEntity(100, new List<IItem> {_itemManager.Items.Single(x => x.ItemName == "翡翠")})
            };
        }

        #region Fields

        private readonly IItemManager _itemManager;
        private readonly IEquipmentManager _equipmentManager;

        #endregion
    }
}