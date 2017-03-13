using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Equipment;
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

        public ObservableCollection<EquipmentBase> Equipments { get; private set; }

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
        public UserBattleState(IUserState userState, ISkillManager skillManager, IEquipmentManager equipmentManager)
        {
            UserState = userState;
            _skillManager = skillManager;
            equipmentManager.OnEquipmentChanged += OnEquipmentChanged;
            UserState.LevelUp += (sender, args) => Initialize();
            Initialize();
        }

        private void OnEquipmentChanged(object sender, EquipmentChangedArgs e)
        {
            foreach (var battleProperty in UserProperty)
            {
                //Compose those properties
            }
        }

        public UserBattleState ResetBattleState()
        {
            Initialize();
            return this;
        }

        #region Private methods

        private void Initialize()
        {
            UserProperty = new ObservableCollection<IBattleProperty>
            {
                new PropertyHp(UserState),
                new PropertyAttack(UserState)
            };
            CurrentHp = MaximumHp;
            CurrentAttack = UserProperty.Single(x => x.Name == "攻击").FinalValue;
            Skills = _skillManager.Skills.Where(x => x.IsChecked);
        }

        #endregion

        #region Fields

        private int _currentAttack;
        private int _currentHp;

        private readonly ISkillManager _skillManager;

        #endregion
    }
}