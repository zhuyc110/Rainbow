using System.ComponentModel.Composition;
using System.Linq;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.Model.Enchantment
{
    [Export(typeof(IEnchantmentManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EnchantmentManager : IEnchantmentManager
    {
        [ImportingConstructor]
        public EnchantmentManager(IRandom random)
        {
            _random = random;
        }

        #region IEnchantmentManager Members

        public string Enchant(EquipmentBase equipment)
        {
            var rate = _random.Next(100) / 100.0;
            var rate2 = _random.Next(80, 100) / 100.0;

            foreach (var property in equipment.EnchantmentProperties)
            {
                property.AbsoluteEnhancement = (int) (equipment.EquipmentProperties.Single(x => x.Name == property.Name).AbsoluteEnhancement * rate * rate2);
            }

            var rateLevel = rate * rate2;

            if (rateLevel > 95)
            {
                return "S";
            }
            if (rateLevel > 90)
            {
                return "A";
            }
            if (rateLevel > 80)
            {
                return "B";
            }
            if (rateLevel > 60)
            {
                return "C";
            }
            return "D";
        }

        #endregion

        #region Fields

        private readonly IRandom _random;

        #endregion
    }
}