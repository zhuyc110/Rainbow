using System;
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
        public EnchantmentManager(IRandom random, IUserState userState, IIOService ioService)
        {
            _random = random;
            _userState = userState;
            _ioService = ioService;
        }

        #region IEnchantmentManager Members

        public int CalculateCost(EquipmentBase equipment)
        {
            const int baseCost = 1000;

            return baseCost * equipment.EnchantmentProperties.Count();
        }

        public string CalculateEnchantLevel(EquipmentBase equipment)
        {
            var enchantmentProperty = equipment.EnchantmentProperties.First();
            var equipmentProperty = equipment.EquipmentProperties.Single(x => x.Name == enchantmentProperty.Name);
            var rateLevel = (double)enchantmentProperty.AbsoluteEnhancement / equipmentProperty.AbsoluteEnhancement;

            if (rateLevel >= 0.95)
            {
                _preEnchantmentLevel = "S";
            }
            else if (rateLevel >= 0.90)
            {
                _preEnchantmentLevel = "A";
            }
            else if (rateLevel >= 0.80)
            {
                _preEnchantmentLevel = "B";
            }
            else if (rateLevel >= 0.60)
            {
                _preEnchantmentLevel = "C";
            }
            else
            {
                _preEnchantmentLevel = "D";
            }
            return _preEnchantmentLevel;
        }

        public string Enchant(EquipmentBase equipment)
        {
            var cost = CalculateCost(equipment);
            if (_userState.Gold < cost)
            {
                _ioService.ShowMessage("没钱了！", "没有足够的钱来附魔");
                return _preEnchantmentLevel;
            }
            _userState.Gold -= cost;

            var rate = _random.Next(100) / 100.0;
            var rate2 = _random.Next(80, 100) / 100.0;

            foreach (var property in equipment.EnchantmentProperties)
            {
                property.AbsoluteEnhancement =
                    Math.Max((int) (equipment.EquipmentProperties.Single(x => x.Name == property.Name).AbsoluteEnhancement * rate * rate2), 1);
            }

            return CalculateEnchantLevel(equipment);
        }

        #endregion

        #region Fields

        private string _preEnchantmentLevel = "D";

        private readonly IRandom _random;
        private readonly IUserState _userState;
        private readonly IIOService _ioService;

        #endregion
    }
}