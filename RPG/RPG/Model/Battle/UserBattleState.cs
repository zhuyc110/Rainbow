using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using log4net;
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
        public UserBattleState(IUserState userState, ISkillManager skillManager, IEquipmentManager equipmentManager, IEnchantmentManager enchantmentManager,
            IAchievementManager achievementManager)
        {
            UserState = userState;
            _skillManager = skillManager;
            _equipmentManager = equipmentManager;
            _achievementManager = achievementManager;

            skillManager.CheckedSkillChanged += (sender, args) => ComposeUserSkills();
            equipmentManager.OnEquipmentChanged += (sender, args) => ResetBattleState();
            UserState.LevelUp += (sender, args) => ResetBattleState();
            enchantmentManager.EquipedEquipmentEnchantmentChanged += (sender, args) => ResetBattleState();
            achievementManager.OnAchievementGet += (sender, args) => ResetBattleState();
            ResetBattleState();
        }

        public UserBattleState ResetBattleState()
        {
            InitializeUserProperties();
            ComposeUserSkills();
            ComposeEquipmentProperties();
            ComposeEquipmentEnchantProperties();
            ComposeAchievementProperties();

            OnPropertyChanged(nameof(UserProperty));

            CurrentHp = MaximumHp;
            CurrentAttack = UserProperty.Single(x => x.Name == "攻击").FinalValue;

            return this;
        }

        #region IBattleEntity Members

        public IBattleEntity NewInstance()
        {
            return ResetBattleState();
        }

        #endregion

        #region Private methods

        private void ComposeAchievementProperties()
        {
            foreach (var achievement in _achievementManager.Achievements.Where(x => x.Achived))
            {
                foreach (var achivementProperty in achievement.AchivementProperties)
                {
                    var property = UserProperty.FirstOrDefault(x => x.Name == achivementProperty.Name);
                    if (property == null)
                    {
                        Log.Warn($"Property: {achivementProperty.Name} is not supported yet.");
                        continue;
                    }

                    property.AbsoluteEnhancement += achivementProperty.AbsoluteEnhancement;
                    property.RelativeEnhancement += achivementProperty.RelativeEnhancement;
                }
            }
        }

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
        private readonly IAchievementManager _achievementManager;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}