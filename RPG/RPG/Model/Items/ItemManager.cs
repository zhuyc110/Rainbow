using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using log4net;
using RPG.Model.Interfaces;

namespace RPG.Model.Items
{
    [Serializable]
    public class ItemManager : IItemManager
    {
        public event EventHandler OnItemPropertyChange;

        public HashSet<ItemBase> AllGameItems => ItemsIdDictionary;

        public ObservableCollection<ItemBase> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                BindingOperations.EnableCollectionSynchronization(_items, _threadLock);
            }
        }

        static ItemManager()
        {
            ItemsIdDictionary = new HashSet<ItemBase>();
        }

        public ItemManager()
        {
            Items = new ObservableCollection<ItemBase>();
        }

        #region IItemManager Members

        public void AddItem(ItemBase newItem)
        {
            var itemInCollection = Items.FirstOrDefault(x => x.ItemName == newItem.ItemName);
            if (itemInCollection == null)
            {
                newItem.PropertyChanged += OnItemPropertyChanged;
                Items.Add(newItem);
            }
            else
            {
                itemInCollection.Amount += newItem.Amount;
            }
        }

        public void AddItem(string newItem, int amount)
        {
            var item = ItemsIdDictionary.Single(x => x.ItemName == newItem).Clone() as ItemBase;
            if (item != null)
            {
                item.Amount = amount;
                item.PropertyChanged += OnItemPropertyChanged;
                AddItem(item);
            }
        }

        public ItemBase CreateItem(string name, int amount = 1)
        {
            var item = ItemsIdDictionary.FirstOrDefault(x => x.ItemName == name);
            if (item == null)
            {
                Log.Error($"None of the item names is {name}");
                throw new ArgumentException(name);
            }

            var result = item.Clone() as ItemBase;
            if (result != null)
            {
                result.Amount = amount;
                return result;
            }
            throw new ArgumentException(name);
        }

        public void RemoveItem(ItemBase newItem)
        {
            var itemInCollection = Items.FirstOrDefault(x => x.ItemName == newItem.ItemName);
            if (itemInCollection != null)
            {
                itemInCollection.PropertyChanged -= OnItemPropertyChanged;
                Items.Remove(newItem);
            }
            else
            {
                Log.Warn($"No item {newItem.ItemName} exists in collection.");
            }
        }

        public void SellItem(string item, int amount = 1)
        {
            var itemInfo = Items.FirstOrDefault(x => x.ItemName == item);
            if (itemInfo == null || itemInfo.Amount < amount)
                return;

            itemInfo.Amount -= amount;
            if (itemInfo.Amount == 0)
            {
                RemoveItem(itemInfo);
            }
        }

        #endregion

        #region Private methods

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaiseOnItemPropertyChange();
        }

        private void RaiseOnItemPropertyChange()
        {
            OnItemPropertyChange?.Invoke(null, null);
        }

        #endregion

        #region Fields

        public static readonly HashSet<ItemBase> ItemsIdDictionary;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly object _threadLock = new object();

        private ObservableCollection<ItemBase> _items;

        #endregion
    }
}