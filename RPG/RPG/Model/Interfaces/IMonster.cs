using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IMonster))]
    public interface IMonster : IBattleEntity
    {
        string Title { get; }

        string MonsterName { get; }

        int Level { get; }

        MonsterClass Class { get; }

        string IconResource { get; }

        new IMonster NewInstance();

        IEnumerable<string> DropList { get; }
    }
}