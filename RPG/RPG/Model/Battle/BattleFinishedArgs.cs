using System;
using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    public class BattleFinishedArgs : EventArgs
    {
        public BattleFinishedArgs(bool userVitoried, IEnumerable<IItem> items, int gold)
        {
            IsUserVictoried = userVitoried;
            Items = items;
            Gold = gold;
        }

        public bool IsUserVictoried { get; }

        public IEnumerable<IItem> Items { get; }

        public int Gold { get; }
    }
}