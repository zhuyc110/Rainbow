using System.Collections.ObjectModel;

namespace RPG.Model.Interfaces
{
    public interface ISkillManager
    {
        ObservableCollection<ISkill> Skills { get; }
    }
}
