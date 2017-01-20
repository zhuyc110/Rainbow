using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyAttack : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyAttack(IUserState userState) : base("攻击")
        {
            _userState = userState;
            Basic = 20 + (_userState.Level > 1 ? 5 : 0) + _userState.Level - 1;
        }

        public PropertyAttack() : base("攻击")
        {
        }

        private readonly IUserState _userState;
    }
}
