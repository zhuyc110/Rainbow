using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyHP : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyHP(IUserState userState) : base("生命")
        {
            _userState = userState;
            Basic = 100 + (_userState.Level > 1 ? 14 : 0) + _userState.Level - 1;
        }
        private readonly IUserState _userState;
    }
}
