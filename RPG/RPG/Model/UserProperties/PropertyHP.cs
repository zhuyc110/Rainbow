using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyHP : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyHP(IUserState userState) : base("生命", userState)
        {
        }

        public PropertyHP() : base("生命", new UserState())
        {
        }

        protected override void SetBasicValue()
        {
            Basic = 100 + (UserState.Level > 1 ? 14 : 0) + UserState.Level - 1;
        }
    }
}