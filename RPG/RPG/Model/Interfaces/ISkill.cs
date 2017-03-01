﻿using System.ComponentModel.Composition;

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
        double Rate { get; set; }

        double AttackRate { get; }
        int AttackFrequency { get; }
    }
}