using System.Collections.Generic;
using RPG.Model.Bonus;

namespace RPG.Model.Interfaces
{
    public interface IBonusManager
    {
        IEnumerable<BonusEntity> BonusEntities { get; }

        void GetBonus(BonusEntity bonus);
    }
}