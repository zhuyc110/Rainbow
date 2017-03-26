using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Battle
{
    [Export(typeof(UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase, IBattleEntity
    {
        public ObservableCollection<IBattleProperty> UserProperty { get; private set; }

        public IUserState UserState { get; }

        public IEnumerable<ISkill> Skills { get; private set; }

        public int CurrentAttack
        {
            get { return _currentAttack; }
            set { SetProperty(ref _currentAttack, value); }
        }

        public int CurrentHp
        {
            get { return _currentHp; }
            set
            {
                SetProperty(ref _currentHp, value);
                OnPropertyChanged(nameof(CurrentHpPercentage));
            }
        }

        public double CurrentHpPercentage
            => CurrentHp / (double) MaximumHp * 100.0;

        public int MaximumHp => UserProperty.Single(x => x.Name == "生命").FinalValue;

        [ImportingConstructor]
        public UserBattleState(IUserState userState, ISkillManager skillManager, IEquipmentManager equipmentManager, IEnchantmentManager enchantmentManager)
        {
            UserState = userState;
            _skillManager = skillManager;
            _equipmentManager = equipmentManager;

            skillManager.CheckedSkillChanged += (sender, args) => ComposeUserSkills();
            equipmentManager.OnEquipmentChanged += (sender, args) =>
            {
                InitializeUserProperties();
                ComposeEquipmentProperties();
                ComposeEquipmentEnchantProperties();
            };
            UserState.LevelUp += (sender, args) => ComposeUserProperties();
            enchantmentManager.EquipedEquipmentEnchantmentChanged += (sender, args) => ComposeEquipmentEnchantProperties();
            ResetBattleState();
        }

        public UserBattleState ResetBattleState()
        {
            ComposeUserProperties();
            ComposeUserSkills();
            ComposeEquipmentProperties();
            ComposeEquipmentEnchantProperties();
            return this;
        }

        #region Private methods

        private void ComposeEquipmentEnchantProperties()
        {
            foreach (var equipment in _equipmentManager.Equipments.Where(x => x.IsEquiped))
            {
                foreach (var enchantmentProperty in equipment.EnchantmentProperties)
                {
                    var property = UserProperty.Single(x => x.Name == enchantmentProperty.Name);
                    property.AbsoluteEnhancement += enchantmentProperty.AbsoluteEnhancement;
                    property.RelativeEnhancement += enchantmentProperty.RelativeEnhancement;
                }
            }
            OnPropertyChanged(nameof(UserProperty));
        }

        private void ComposeEquipmentProperties()
        {
            foreach (var equipment in _equipmentManager.Equipments.Where(x => x.IsEquiped))
            {
                foreach (var equipmentProperty in equipment.EquipmentProperties)
                {
                    var property = UserProperty.Single(x => x.Name == equipmentProperty.Name);
                    property.AbsoluteEnhancement += equipmentProperty.AbsoluteEnhancement;
                    property.RelativeEnhancement += equipmentProperty.RelativeEnhancement;
                }
            }
            OnPropertyChanged(nameof(UserProperty));
        }

        private void ComposeUserProperties()
        {
            InitializeUserProperties();
            CurrentHp = MaximumHp;
            CurrentAttack = UserProperty.Single(x => x.Name == "攻击").FinalValue;
        }

        private void ComposeUserSkills()
        {
            Skills = _skillManager.Skills.Where(x => x.IsChecked);
        }

        private void InitializeUserProperties()
        {
            UserProperty = new ObservableCollection<IBattleProperty>
            {
                new PropertyHp(UserState),
                new PropertyAttack(UserState)
            };
        }

        #endregion

        #region Fields

        private int _currentAttack;
        private int _currentHp;

        private readonly ISkillManager _skillManager;
        private readonly IEquipmentManager _equipmentManager;

        #endregion
    }
}