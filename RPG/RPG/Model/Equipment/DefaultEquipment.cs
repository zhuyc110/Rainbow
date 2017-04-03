using System.Collections.Generic;
using System.Linq;
using RPG.Model.UserProperties;

namespace RPG.Model.Equipment
{
    public class DefaultEquipment : EquipmentBase
    {
        public DefaultEquipment(EquipmentPart part)
            : base(Enumerable.Empty<BasicProperty>())
        {
            Rarity = Rarity.Normal;
            Part = part;
        }
    }
}