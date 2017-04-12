using System;
using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    public class BattleFinishedArgs : EventArgs
    {
        public IEnumerable<IMonster> Monsters { get; }

        public bool IsUserVictoried { get; }

        public Dictionary<string, int> Items { get; }

        public int Gold { get; }

        public BattleFinishedArgs(bool userVitoried, Dictionary<string, int> items, int gold, IEnumerable<IMonster> monsters = null)
        {
            IsUserVictoried = userVitoried;
            Items = items;
            Gold = gold;
            Monsters = monsters;
        }
    }
}