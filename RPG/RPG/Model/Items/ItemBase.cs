﻿using System;
using System.ComponentModel.Composition;
using System.Windows;
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
        public event EventHandler<SellEventArgs> OnItemSoldOut;

        #region Properties

        public int Amount
        {
            get { return _amount; }

            set { SetProperty(ref _amount, value > 99 ? 99 : value); }
        }

        public string Content { get; set; }

        public string IconResource { get; set; }

        public long Id { get; set; }

        [Import]
        private IIOService IoService { get; set; }

        public string ItemName { get; set; }

        public Rarity Rarity { get; set; }

        public ICommand SellAll { get; }

        public ICommand SellSelf { get; }

        [Import]
        private IUserState UserState { get; set; }

        public int Worth { get; set; }

        #endregion

        public ItemBase(string itemName, string content, string iconSource, Rarity rarity, int worth,
            bool isCloned = false)
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
            SellSelf = new DelegateCommand(() =>
            {
                if (Amount - 1 == 0)
                {
                    SoldOutConfirm();
                }
                else
                {
                    UserState.Gold += Worth;
                    Amount--;
                }
            });

            SellAll = new DelegateCommand(SoldOutConfirm);
        }

        #region ICloneable Members

        public object Clone()
        {
            var cloned = new ItemBase(ItemName, Content, IconResource, Rarity, Worth, true);
            return cloned;
        }

        #endregion

        private void CalculateId()
        {
            Id = _idSum++;
        }

        private void RaiseSoldOutEvent()
        {
            OnItemSoldOut?.Invoke(null, new SellEventArgs(this));
        }

        private void SoldOutConfirm()
        {
            var confirm = true;
            if (Rarity >= Rarity.Epic)
            {
                var result = IoService.ShowDialog("确认", $"是否将{ItemName}全部卖出？");
                if (result != MessageBoxResult.Yes)
                    confirm = false;
            }

            if (confirm)
            {
                UserState.Gold += Worth * Amount;
                Amount = 0;
                RaiseSoldOutEvent();
            }
        }

        #region Fields

        private static int _idSum;

        private int _amount;

        #endregion
    }
}