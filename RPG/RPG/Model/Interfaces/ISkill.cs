using System.ComponentModel.Composition;
using System.Windows.Media;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(ISkill))]
    public interface ISkill
    {
        string Name { get; }
        string Content { get; }
        int LevelRequirement { get; }
        ImageSource Icon { get; }
        bool IsChecked { get; }
    }
}