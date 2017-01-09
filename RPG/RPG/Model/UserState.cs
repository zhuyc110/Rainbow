using System.ComponentModel.Composition;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Export(typeof(IUserState))]
    public class UserState : IUserState
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public int Level { get; set; }
        public long Gold { get; set; }
        public long Gem { get; set; }
        public long Experience { get; set; }

        [ImportingConstructor]
        public UserState()
        {
            Level = 1;
            Gold = 1000;
            Gem = 100;
            UserName = "Sky - Han";
        }
    }
}
