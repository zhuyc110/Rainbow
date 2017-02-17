using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using log4net;
using RPG.Model.Interfaces;

namespace RPG.Model.Items
{
    [Serializable]
    public class ItemManager : IItemManager
    {
        public event EventHandler OnItemPropertyChange;

        #region Properties

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

        #endregion

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
            item.Amount = amount;
            item.PropertyChanged += OnItemPropertyChanged;
            AddItem(item);
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

        #endregion

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaiseOnItemPropertyChange();
        }

        private void RaiseOnItemPropertyChange()
        {
            OnItemPropertyChange?.Invoke(null, null);
        }

        #region Fields

        public static readonly HashSet<ItemBase> ItemsIdDictionary = new HashSet<ItemBase>
        {
            new ItemBase("石头", "一块石头", "INV_Stone_06", Rarity.Normal, 200),
            new ItemBase("翡翠", "一块翡翠", "INV_Misc_Gem_Emerald_02", Rarity.Rare, 2000)
        };

        private static readonly ILog Log = LogManager.GetLogger(typeof(ItemManager));

        private readonly object _threadLock = new object();

        private ObservableCollection<ItemBase> _items;

        #endregion
    }
}