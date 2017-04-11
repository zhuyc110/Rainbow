using System.Collections.Generic;

namespace RPG.Model.Interfaces
{
    public interface IBattleEntity
    {
        int CurrentHp { get; set; }
        double CurrentHpPercentage { get; }
        int CurrentAttack { get; set; }
        int MaximumHp { get; }
        IEnumerable<ISkill> Skills { get; }

        IBattleEntity NewInstance();
    }
}