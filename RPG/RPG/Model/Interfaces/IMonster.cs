using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IMonster))]
    public interface IMonster : IBattleEntity, INotifyPropertyChanged
    {
        string Title { get; }

        string MonsterName { get; }

        int Level { get; }

        MonsterClass Class { get; }

        string IconResource { get; }

        IEnumerable<string> DropList { get; }

        new IMonster NewInstance();
    }
}