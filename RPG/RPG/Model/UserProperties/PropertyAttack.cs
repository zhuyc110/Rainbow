using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyAttack : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyAttack(IUserState userState)
        {
            _userState = userState;
            Name = "攻击";
            Basic = 20 + _userState.Level > 1 ? 5 : 0 + _userState.Level - 1;
        }

        private readonly IUserState _userState;
    }
}
