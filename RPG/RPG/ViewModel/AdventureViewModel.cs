using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(AdventureViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AdventureViewModel : BindableBase
    {
        public ObservableCollection<IAdventureArea> AdventureAreas { get; }

        [ImportingConstructor]
        public AdventureViewModel()
        {
            AdventureAreas = new ObservableCollection<IAdventureArea>
            {
                new AdventureArea("勇者平原", "BTNWolf", 1, 5),
                new AdventureArea("黑暗森林", "BTNForestTroll", 6, 10),
                new AdventureArea("兽人领地", "BTNGrunt", 11, 15),
                new AdventureArea("死亡沙漠", "BTNArachnathid", 16, 20),
                new AdventureArea("无尽废墟", "BTNOgre", 21, 24),
            };
        }
    }
}
