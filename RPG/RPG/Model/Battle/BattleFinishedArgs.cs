using System;
using System.Collections.Generic;

namespace RPG.Model.Battle
{
    public class BattleFinishedArgs : EventArgs
    {
        public BattleFinishedArgs(bool userVitoried, Dictionary<string,int> items, int gold)
        {
            IsUserVictoried = userVitoried;
            Items = items;
            Gold = gold;
        }

        public bool IsUserVictoried { get; }

        public Dictionary<string, int> Items { get; }

        public int Gold { get; }
    }
}