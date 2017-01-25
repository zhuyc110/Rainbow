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

        string IconResource { get; }

        int CurrentHp { get; set; }

        double CurrentHpPercentage { get; }
    }
}