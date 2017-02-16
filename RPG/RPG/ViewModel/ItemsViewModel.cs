using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.ViewModel
{
    [Export(typeof(ItemsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ItemsViewModel : BindableBase
    {
        #region Properties

        public IItemManager ItemManager { get; set; }

        #endregion

        [ImportingConstructor]
        public ItemsViewModel(IItemManager itemManager)
        {
            foreach (var item in itemManager.Items.OrderBy(x => x.Rarity))
                item.OnItemSoldOut += OnItemSoldOut;
            ItemManager = itemManager;

            ItemManager.Items.CollectionChanged += ItemsCollectionChanged;
        }

        private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action != NotifyCollectionChangedAction.Add)
                return;

            foreach (var newItem in e.NewItems)
            {
                var conventedItem = newItem as ItemBase;
                if (conventedItem != null)
                {
                    conventedItem.OnItemSoldOut += OnItemSoldOut;
                }
            }
        }

        private void OnItemSoldOut(object sender, SellEventArgs e)
        {
            var item = e.Item as ItemBase;
            if (item == null)
                return;

            item.OnItemSoldOut -= OnItemSoldOut;
            ItemManager.RemoveItem(item);
        }
    }
}