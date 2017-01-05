﻿using Prism.Mvvm;
using RPG.Model.Interfaces;
using System.ComponentModel.Composition;

namespace RPG.Model.Items
{
    [InheritedExport(typeof(ItemBase))]
    public abstract class ItemBase : BindableBase, IItem
    {
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
    }
}