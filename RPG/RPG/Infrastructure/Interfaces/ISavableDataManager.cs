using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Infrastructure.Interfaces
{
    public interface ISavableDataManager
    {
        IEnumerable<ISavableData> SavableDatas { get; }

        void SaveData();
    }
}