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
    [Export(nameof(ItemsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ItemsViewModel : BindableBase
    {
        [ImportingConstructor]
        public ItemsViewModel([ImportMany] IEnumerable<IItem> items)
        {
            Items = new ObservableCollection<IItem>();
            foreach (var item in items.OrderBy(x => x.Rarity))
            {
                Items.Add(item);
            }
        }

        [Obsolete("This is ONLY used for Design view")]
        public ItemsViewModel()
        {
            Items = new ObservableCollection<IItem>
            {
                new Stone(),
                new Stone(),
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