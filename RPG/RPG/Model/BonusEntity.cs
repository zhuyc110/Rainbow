using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    public class BonusEntity
    {
        public IEnumerable<IItem> BonusItems { get; private set; }

        public int RequiredGem { get; private set; }
    }
}
