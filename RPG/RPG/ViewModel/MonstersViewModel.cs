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
        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;
        private readonly UserBattleState _userBattleState;

        public MonstersViewModel(IEnumerable<IMonster> monsters, UserBattleState userBattleState, IIOService ioService, IBattleActor battleActor)
        {
            _ioService = ioService;
            _battleActor = battleActor;
            _userBattleState = userBattleState;
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

        public ObservableCollection<IMonster> Monsters { get; }

        public ICommand StartBattleCommand { get; }

        private void StartBattle(string monsterName)
        {
            var view = _ioService.GetView<BattleView>();
            view.ViewModel = new BattleViewModel(_userBattleState, Monsters.Single(x => x.MonsterName == monsterName), _battleActor, _ioService, this);
            _ioService.SwitchView(nameof(MainModule), nameof(BattleView));
        }
    }
}