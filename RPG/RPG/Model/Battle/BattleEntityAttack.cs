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

            foreach (var skill in battleEntity.Skills)
            {
                if (seed < skill.AppearRate * 100)
                {
                    Skill = skill;
                    Damage = (int) (battleEntity.CurrentAttack * skill.DamageRatePerAttack * skill.AttackFrequency);
                    SkillEffect = skill.SkillEffect;
                    break;
                }
            }
        }

        public BattleEntityAttack()
        {
            
        }
    }
}