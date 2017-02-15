using System;
using System.Collections.ObjectModel;
using RPG.Model.Items;

namespace RPG.Model.Interfaces
{
    public interface IItemManager
    {
        event EventHandler OnItemPropertyChange;

        ObservableCollection<ItemBase> Items { get; }

        void AddItem(ItemBase newItem);

        void RemoveItem(ItemBase newItem);
    }
}
