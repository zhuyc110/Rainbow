using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Items
{
    public abstract class ItemBase : BindableBase, IItem
    {
        private int _amount = 0;

        public int Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                SetProperty(ref _amount, value);
            }
        }

        public string Content { get; protected set; }

        public string IconResource { get; protected set; }

        public string Name { get; protected set; }

        public Rarity Rarity { get; protected set; }

        public int Worth { get; protected set; }
    }
}