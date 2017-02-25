using System;
using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    public class BattleFinishedArgs : EventArgs
    {
        public BattleFinishedArgs(bool userVitoried, Dictionary<string,int> items, int gold, IMonster monster = null)
        {
            IsUserVictoried = userVitoried;
            Items = items;
            Gold = gold;
            Monster = monster;
        }

        public IMonster Monster { get; }

        public bool IsUserVictoried { get; }

        public Dictionary<string, int> Items { get; }

        public int Gold { get; }
    }
}