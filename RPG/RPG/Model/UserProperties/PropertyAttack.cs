using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public class PropertyAttack : UserPropertyBase
    {
        [ImportingConstructor]
        public PropertyAttack(IUserState userState) : base("攻击", userState)
        {
        }

        public PropertyAttack() : base("攻击", new UserState())
        {
        }

        protected override void SetBasicAndFinalValue()
        {
            Basic = 20 + (UserState.Level > 1 ? 5 : 0) + UserState.Level - 1;
        }
    }
}