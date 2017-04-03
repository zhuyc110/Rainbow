using System.Collections.Generic;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    public class BonusEntity
    {
        public IEnumerable<IItem> BonusItems { get; private set; }

        public int RequiredGem { get; private set; }

        public BonusEntity(int requiredGem, IEnumerable<IItem> bonusItems)
        {
            RequiredGem = requiredGem;
            BonusItems = bonusItems;
        }
    }
}