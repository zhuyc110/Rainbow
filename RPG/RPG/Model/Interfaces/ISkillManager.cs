using System;
using System.Collections.ObjectModel;

namespace RPG.Model.Interfaces
{
    public interface ISkillManager
    {
        ObservableCollection<ISkill> Skills { get; }

        event EventHandler CheckedSkillChanged;
    }
}
