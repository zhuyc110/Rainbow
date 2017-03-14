using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Model.Battle;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CharacterViewModel : BindableBase
    {
        public IEquipmentManager EquipmentManager { get; }

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

        private void EquipmentManagerOnEquipmentChanged(object sender, Model.Equipment.EquipmentChangedArgs e)
        {
            var newE = e.NewEquipment;
        }
    }
}