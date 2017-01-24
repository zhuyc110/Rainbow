using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(AdventureViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AdventureViewModel : BindableBase
    {
        private IAdventureArea _selectedArea;

        [ImportingConstructor]
        public AdventureViewModel()
        {
            AdventureAreas = new ObservableCollection<IAdventureArea>
            {
                new AdventureArea("勇者平原", "BTNWolf", 1, 5),
                new AdventureArea("黑暗森林", "BTNForestTroll", 6, 10),
                new AdventureArea("兽人领地", "BTNGrunt", 11, 15),
                new AdventureArea("死亡沙漠", "BTNArachnathid", 16, 20),
                new AdventureArea("无尽废墟", "BTNOgre", 21, 24)
            };

            OpenAreaCommand = new DelegateCommand<string>(OnOpenArea);
        }

        public ObservableCollection<IAdventureArea> AdventureAreas { get; }

        public IAdventureArea SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }

        public ICommand OpenAreaCommand { get; }

        private void OnOpenArea(string areaName)
        {
            if ((SelectedArea = AdventureAreas.First(x => x.AreaName == areaName)) == null)
                return;

            Debug.Print(SelectedArea.AreaName);
        }
    }
}