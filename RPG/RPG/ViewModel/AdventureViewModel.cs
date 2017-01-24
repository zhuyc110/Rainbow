using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Module;
using RPG.View.MainView;

namespace RPG.ViewModel
{
    [Export(typeof(AdventureViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AdventureViewModel : BindableBase
    {
        private IAdventureArea _selectedArea;
        private readonly IIOService _ioService;

        [ImportingConstructor]
        public AdventureViewModel(IIOService ioService)
        {
            _ioService = ioService;

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

        [ImportMany]
        private IEnumerable<IMonster> Monsters { get; set; }

        private void OnOpenArea(string areaName)
        {
            if ((SelectedArea = AdventureAreas.First(x => x.AreaName == areaName)) == null)
                return;
            
            var view = _ioService.GetView<MonstersView>();
            view.DataContext = new MonstersViewModel(Monsters);
            _ioService.SwitchView(nameof(MainModule), nameof(MonstersView));
        }
    }
}