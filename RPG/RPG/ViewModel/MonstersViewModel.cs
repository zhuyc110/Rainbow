using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class MonstersViewModel : BindableBase
    {
        public ObservableCollection<IMonster> Monsters { get; }

        public ICommand StartBattleCommand { get; }

        public MonstersViewModel(IEnumerable<IMonster> monsters, UserBattleState userBattleState, IIOService ioService, IBattleActor battleActor, IItemManager itemManager,
            IAchievementManager achievementManager)
        {
            _ioService = ioService;
            _battleActor = battleActor;
            _userBattleState = userBattleState;
            _itemManager = itemManager;
            _achievementManager = achievementManager;
            Monsters = new ObservableCollection<IMonster>(monsters);
            StartBattleCommand = new DelegateCommand<string>(StartBattle);
        }

        [Obsolete]
        public MonstersViewModel()
        {
            Monsters = new ObservableCollection<IMonster>
            {
                new MonsterSlime(new MyRandom())
            };
        }

        #region Private methods

        private void StartBattle(string monsterName)
        {
            var view = _ioService.GetView<BattleView>();
            view.ViewModel = new BattleViewModel(_userBattleState.ResetBattleState(), Monsters.Single(x => x.MonsterName == monsterName).NewInstance(), _battleActor,
                _ioService, _itemManager, _achievementManager, this);
            _ioService.SwitchView(nameof(MainModule), nameof(BattleView));
        }

        #endregion

        #region Fields

        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;
        private readonly UserBattleState _userBattleState;
        private readonly IItemManager _itemManager;
        private readonly IAchievementManager _achievementManager;

        #endregion
    }
}