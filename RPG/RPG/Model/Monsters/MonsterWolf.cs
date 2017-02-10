using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Monsters
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MonsterWolf : MonsterBase
    {
        [ImportingConstructor]
        public MonsterWolf(IRandom random) : base("狼", 2, "INV_Stone_15", random)
        {
            var rel = 1 + (int)Class / 10.0;

            Properties = new List<IBattleProperty>
            {
                new PropertyHp {Basic = (int) (100*rel)},
                new PropertyAttack {Basic = (int) (25*rel)}
            };
            CurrentAttack = Properties.Single(x => x.Name == "攻击").FinalValue;
            CurrentHp = MaximumHp;
            DropList = new List<string> { "石头" };
        }

        public override IMonster NewInstance()
        {
            return new MonsterWolf(MyRandom);
        }
    }
}
