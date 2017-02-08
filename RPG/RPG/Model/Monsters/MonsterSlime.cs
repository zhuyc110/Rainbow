using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Monsters
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MonsterSlime : MonsterBase
    {
        [ImportingConstructor]
        public MonsterSlime(IRandom random) : base("史莱姆", 1, "INV_Stone_15", random, "创世之")
        {
            var rel = 1 + (int)Class / 10.0;

            Properties = new List<IBattleProperty>
            {
                new PropertyHP {Basic = (int) (80*rel)},
                new PropertyAttack {Basic = (int) (10*rel)}
            };
            CurrentAttack = Properties.Single(x => x.Name == "攻击").FinalValue;
            CurrentHp = MaximumHp;
            DropList = new List<string> { "石头" };
        }

        public override IMonster NewInstance()
        {
            return new MonsterSlime(MyRandom);
        }
    }
}