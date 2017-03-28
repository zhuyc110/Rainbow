using System;

namespace RPG.Model.Items
{
    public class SellEventArgs : EventArgs
    {
        public int Amount { get; }

        public string Item { get; }

        public SellEventArgs(string item, int amount = 1)
        {
            Item = item;
            Amount = amount;
        }
    }
}