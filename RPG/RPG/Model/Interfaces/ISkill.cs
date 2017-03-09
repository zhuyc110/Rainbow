using System.ComponentModel.Composition;
using RPG.Model.Skills;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(ISkill))]
    public interface ISkill
    {
        string Name { get; }
        string Content { get; }
        int LevelRequirement { get; }
        string IconResource { get; }
        bool IsChecked { get; set; }
        bool IsVisible { get; set; }
        double AppearRate { get; set; }

        double DamageRatePerAttack { get; }
        int AttackFrequency { get; }

        SkillEffect SkillEffect { get; }
    }
}