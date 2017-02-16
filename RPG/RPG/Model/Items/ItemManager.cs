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

        public ObservableCollection<ItemBase> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                BindingOperations.EnableCollectionSynchronization(_items, _threadLock);
            }
        }

        public static readonly HashSet<ItemBase> ItemsIdDictionary = new HashSet<ItemBase>
        {
            
        };

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

        private static readonly ILog Log = LogManager.GetLogger(typeof(ItemManager));

        private readonly object _threadLock = new object();

        private ObservableCollection<ItemBase> _items;

        #endregion
    }
}