using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyHp : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyHp(IUserState userState) : base("生命", userState)
        {
        }

        public PropertyHp() : base("生命", new UserState())
        {
        }

        protected override void SetBasicValue()
        {
            Basic = 100 + (UserState.Level > 1 ? 14 : 0) + UserState.Level - 1;
        }
    }
}