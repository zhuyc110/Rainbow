using System.Collections.Generic;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    public class BonusEntity : BindableBase
    {
        public IEnumerable<IItem> BonusItems { get; }

        public int RequiredGem { get; }

        public bool CanGetBonus => _userState.Gem > RequiredGem;

        public BonusEntity(int requiredGem, IEnumerable<IItem> bonusItems, IUserState userState)
        {
            RequiredGem = requiredGem;
            BonusItems = bonusItems;
            _userState = userState;
            _userState.GemChanged += (sender, args) => { OnPropertyChanged(nameof(CanGetBonus)); };
        }

        #region Fields

        private readonly IUserState _userState;

        #endregion
    }
}