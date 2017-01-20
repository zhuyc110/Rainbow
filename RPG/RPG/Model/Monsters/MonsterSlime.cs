using System.Collections.Generic;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model.Monsters
{
    public class MonsterSlime : MonsterBase
    {
        public MonsterSlime() : base("史莱姆", 1, "iconResource")
        {
            var rel = 1 + (int)Class / 10.0;

            Properties = new List<IBattleProperty>
            {
                new PropertyHP {Basic = (int) (80*rel)},
                new PropertyAttack {Basic = (int) (10*rel)}
            };
        }
    }
}