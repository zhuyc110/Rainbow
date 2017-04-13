using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Implementation;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Battle;
using RPG.Model.Interfaces;
using RPG.Model.Monsters;
using RPG.Module;
using RPG.View.MainView;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DuplicationsViewModel : BindableBase
    {
        public ObservableCollection<DuplicationViewModel> Duplications { get; }

        public ICommand StartDuplicationCommand { get; }

        [Import]
        private IAchievementManager AchievementManager { get; set; }

        [Import]
        private IItemManager ItemManager { get; set; }

        [ImportingConstructor]
        public DuplicationsViewModel([ImportMany] IEnumerable<IMonster> monsters, UserBattleState userBattleState, IBattleActor battleActor, IIOService ioService)
        {
            _userBattleState = userBattleState;
            _battleActor = battleActor;
            _ioService = ioService;
            Duplications = new ObservableCollection<DuplicationViewModel>
            {
                new DuplicationViewModel(monsters, 1)
            };
            StartDuplicationCommand = new DelegateCommand<DuplicationViewModel>(StartDuplication);
        }

        public DuplicationsViewModel()
        {
            Duplications = new ObservableCollection<DuplicationViewModel>
            {
                new DuplicationViewModel(new[] {new MonsterSlime(new MyRandom())}, 1)
            };
        }

        #region Private methods

        private async void StartDuplication(DuplicationViewModel duplication)
        {
            _ioService.SwitchView(nameof(MainModule), nameof(BattleView));
            var view = _ioService.GetView<BattleView>();
            view.ViewModel = new BattleViewModel(_userBattleState.ResetBattleState(), duplication.Monsters.Select(x => x.NewInstance()), _battleActor,
                _ioService, ItemManager, AchievementManager);
            await view.ViewModel.StartMultiBattle();
        }

        #endregion

        #region Fields

        private readonly UserBattleState _userBattleState;
        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;

        #endregion
    }
}