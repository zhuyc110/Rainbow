using RPG.Model.Interfaces;
using System;

namespace RPG.Model.Items
{
    public class SellEventArgs : EventArgs
    {
        public IItem Item { get; }

        public SellEventArgs(IItem item)
        {
            Item = item;
        }
    }
}