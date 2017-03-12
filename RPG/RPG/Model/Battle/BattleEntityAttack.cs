using System.Linq;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;
using RPG.Model.Skills;

namespace RPG.Model.Battle
{
    public class BattleEntityAttack
    {
        public SkillEffect SkillEffect { get; set; }
        public int Damage { get; set; }
        public ISkill Skill { get; }

        public BattleEntityAttack(IBattleEntity battleEntity, IRandom random)
        {
            Damage = battleEntity.CurrentAttack;

            var seed = random.Next(100);

            var matchedSkills = battleEntity.Skills.Where(x => x.AppearRate * 100 > seed).ToList();
            if (!matchedSkills.Any())
            {
                return;
            }

            var matchedSkillIndex = random.Next(matchedSkills.Count);

            Skill = matchedSkills[matchedSkillIndex];
            Damage = (int)(battleEntity.CurrentAttack * Skill.DamageRatePerAttack * Skill.AttackFrequency);
            SkillEffect = Skill.SkillEffect;
        }

        public BattleEntityAttack()
        {
            
        }
    }
}