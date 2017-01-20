using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Infrastructure.Interfaces
{
    public interface IMonsterManager
    {
        IEnumerable<IMonster> Monsters { get; set; }
    }
}