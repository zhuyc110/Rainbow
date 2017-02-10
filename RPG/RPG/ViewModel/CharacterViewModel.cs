using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Battle;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CharacterViewModel : BindableBase
    {
        #region Properties

        public UserBattleState UserBattleState { get; }

        #endregion

        [ImportingConstructor]
        public CharacterViewModel(UserBattleState userBattleState)
        {
            UserBattleState = userBattleState;

            UserBattleState.UserState.LevelUp += (sender, args) =>
            {
                OnPropertyChanged(nameof(UserBattleState));
            };
        }
    }
}