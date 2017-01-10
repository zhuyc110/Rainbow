using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [ImportingConstructor]
        public ItemsViewModel([ImportMany] IEnumerable<ItemBase> items)
        {
            Items = new ObservableCollection<IItem>();
            foreach (var item in items.OrderBy(x => x.Rarity))
            {
                item.OnItemSoldOut += Item_OnItemSoldOut;
                Items.Add(item);
            }
        }

        private void Item_OnItemSoldOut(object sender, SellEventArgs e)
        {
            var item = e.Item as ItemBase;
            if(item == null)
            {
                return;
            }

            item.OnItemSoldOut -= Item_OnItemSoldOut;
            Items.Remove(item);
        }

        [Obsolete("This is ONLY used for Design view")]
        public ItemsViewModel()
        {
            Items = new ObservableCollection<IItem>
            {
                new Stone { Amount = 100 },
                new Stone { Amount = 10 },
                new Stone(),
                new Stone(),
                new Stone(),
                new Stone(),
                new Stone(),
                new Stone()
            };
        }

        public ObservableCollection<IItem> Items { get; }
    }
}