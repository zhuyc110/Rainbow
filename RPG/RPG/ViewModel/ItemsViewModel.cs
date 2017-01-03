using Prism.Mvvm;
using RPG.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace RPG.ViewModel
{
    [Export(nameof(ItemsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ItemsViewModel : BindableBase
    {
        public ObservableCollection<IItem> Items { get; private set; }

        [ImportingConstructor]
        public ItemsViewModel([ImportMany]IEnumerable<IItem> items)
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
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone(),
                new Model.Items.Stone()
            };
        }
    }
}