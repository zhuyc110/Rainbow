using System.ComponentModel.Composition;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IMonster))]
    public interface IMonster
    {
        string Title { get; }

        string MonsterName { get; }

        int Level { get; }

        MonsterClass Class { get; }
    }
}