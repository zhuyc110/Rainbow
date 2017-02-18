using System;

namespace RPG.Model.Items
{
    public class SellEventArgs : EventArgs
    {
        #region Properties

        public int Amount { get; }
        public string Item { get; }

        #endregion

        public SellEventArgs(string item, int amount = 1)
        {
            Item = item;
            Amount = amount;
        }
    }
}