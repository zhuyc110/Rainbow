using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Battle;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CharacterViewModel : BindableBase
    {
        public IEquipmentManager EquipmentManager { get; }

        public EquipmentBase Helmet => EquipmentManager[EquipmentPart.Helmet];
        public EquipmentBase Breastplate => EquipmentManager[EquipmentPart.Breastplate];
        public EquipmentBase Legging => EquipmentManager[EquipmentPart.Legging];
        public EquipmentBase Weapon => EquipmentManager[EquipmentPart.Weapon];
        public EquipmentBase Wing => EquipmentManager[EquipmentPart.Wing];
        public EquipmentBase Accessory => EquipmentManager[EquipmentPart.Accessory];
        public EquipmentBase Necklace => EquipmentManager[EquipmentPart.Necklace];
        public EquipmentBase Glove => EquipmentManager[EquipmentPart.Glove];
        public EquipmentBase Ring => EquipmentManager[EquipmentPart.Ring];
        public EquipmentBase Boot => EquipmentManager[EquipmentPart.Boot];

        #region Properties

        public UserBattleState UserBattleState { get; }

        #endregion

        [ImportingConstructor]
        public CharacterViewModel(UserBattleState userBattleState, IEquipmentManager equipmentManager)
        {
            UserBattleState = userBattleState;
            EquipmentManager = equipmentManager;
            EquipmentManager.OnEquipmentChanged += EquipmentManagerOnEquipmentChanged;
            UserBattleState.UserState.LevelUp += (sender, args) => OnPropertyChanged(nameof(UserBattleState));
        }

        #region Private methods

        private void EquipmentManagerOnEquipmentChanged(object sender, EquipmentChangedArgs e)
        {
            OnPropertyChanged(e.NewEquipment.Part.ToString());
        }

        #endregion
    }
}