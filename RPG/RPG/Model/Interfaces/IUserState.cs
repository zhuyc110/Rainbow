using System;
using System.Collections.Generic;
using RPG.Model.Items;

namespace RPG.Model.Interfaces
{
    public interface IUserState
    {
        string Title { get; set; }

        string UserName { get; set; }

        int Level { get; set; }

        long Gold { get; set; }

        long Gem { get; set; }

        long Experience { get; set; }

        IList<ItemBase> Items { get; }

        void AddItem(ItemBase newItem);

        event EventHandler LevelUp;

        event EventHandler ExpChanged;
    }
}