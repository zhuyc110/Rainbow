using System.ComponentModel.Composition;

namespace RPG.Model.Interfaces
{
    [InheritedExport(typeof(IItem))]
    public interface IItem
    {
        string Name { get; }

        string Content { get; }

        Rarity Rarity { get; }

        int Worth { get; }

        int Amount { get; set; }

        string IconResource { get; }
    }
}