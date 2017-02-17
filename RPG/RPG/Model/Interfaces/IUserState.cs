using System;
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

        ItemManager ItemManager { get; set; }

        void AddItem(ItemBase newItem);

        void AddItem(string newItem, int amount);

        event EventHandler LevelUp;

        event EventHandler ExpChanged;
    }
}