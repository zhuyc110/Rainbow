using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace RPG.Model.Items
{
    [InheritedExport(typeof(ItemBase))]
    public abstract class ItemBase : BindableBase, IItem
    {
        public event EventHandler<SellEventArgs> OnItemSoldOut;

        private int _amount;

        public int Amount
        {
            get { return _amount; }

            set
            {
                SetProperty(ref _amount, value > 99 ? 99 : value);
            }
        }

        public string Content { get; protected set; }

        public string IconResource { get; set; }

        public string ItemName { get; set; }

        public Rarity Rarity { get; protected set; }

        public int Worth { get; protected set; }

        public ICommand SellSelf { get; }

        public ICommand SellAll { get; }

        [Import]
        private IIOService IoService { get; set; }

        [Import]
        private IUserState UserState { get; set; }

        protected ItemBase()
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

        private void SoldOutConfirm()
        {
            var confirm = true;
            if (Rarity >= Rarity.Epic)
            {
                var result = IoService.ShowDialog("确认", $"是否将{ItemName}全部卖出？");
                if (result != System.Windows.MessageBoxResult.Yes)
                {
                    confirm = false;
                }
            }

            if (confirm)
            {
                UserState.Gold += Worth * Amount;
                Amount = 0;
                RaiseSoldOutEvent();
            }
        }

        private void RaiseSoldOutEvent()
        {
            OnItemSoldOut.Invoke(null, new SellEventArgs(this));
        }
    }
}