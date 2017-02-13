using System;

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

        event EventHandler LevelUp;

        event EventHandler ExpChanged;
    }
}