using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Items
{
    [Serializable]
    //[InheritedExport(typeof(ItemBase))]
    public class ItemBase : BindableBase, IItem, ICloneable
    {
        public event EventHandler<SellEventArgs> OnItemSelling;

        public int Amount
        {
            get { return _amount; }

            set { SetProperty(ref _amount, value > 99 ? 99 : value); }
        }

        public string Content { get; set; }

        public string IconResource { get; set; }

        public long Id { get; set; }

        public string ItemName { get; set; }

        public Rarity Rarity { get; set; }

        public ICommand SellCommand { get; }

        public int Worth { get; set; }

        [Import]
        private IIOService IoService { get; set; }

        [Import]
        private IUserState UserState { get; set; }

        public ItemBase(string itemName, string content, string iconSource, Rarity rarity, int worth,
            bool isCloned = false) : this()
        {
            ItemName = itemName;
            Content = content;
            IconResource = iconSource;
            Rarity = rarity;
            Worth = worth;
            if (!isCloned)
                CalculateId();
        }

        public ItemBase()
        {
            SellCommand = new DelegateCommand<int?>(RaiseSellItem);
        }

        #region ICloneable Members

        public object Clone()
        {
            var cloned = new ItemBase(ItemName, Content, IconResource, Rarity, Worth, true);
            return cloned;
        }

        #endregion

        #region Private methods

        private void CalculateId()
        {
            Id = _idSum++;
        }

        private void RaiseSellItem(int? amount)
        {
            OnItemSelling?.Invoke(this,
                amount != null ? new SellEventArgs(ItemName, (int) amount) : new SellEventArgs(ItemName));
        }

        #endregion

        #region Fields

        private static int _idSum;

        private int _amount;

        #endregion
    }
}