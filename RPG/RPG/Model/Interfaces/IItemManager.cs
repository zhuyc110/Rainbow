using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RPG.Model.Items;

namespace RPG.Model.Interfaces
{
    public interface IItemManager
    {
        event EventHandler OnItemPropertyChange;

        ObservableCollection<ItemBase> Items { get; }

        HashSet<ItemBase> AllGameItems { get; }

        void AddItem(ItemBase newItem);

        void AddItem(string newItem, int amount);

        void SellItem(string item, int amount);

        void RemoveItem(ItemBase newItem);
    }
}
