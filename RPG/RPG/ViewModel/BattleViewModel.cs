using System;
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
    public class BattleViewModel : BindableBase
    {
        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;
        private readonly MonstersViewModel _parenViewModel;
        private int _damage;
        private bool _isMonsterDamaged;

        public BattleViewModel(UserBattleState userBattleState, IMonster monster, IBattleActor battleActor,
            IIOService ioService, MonstersViewModel parentViewModel)
        {
            UserBattleState = userBattleState;
            Monster = monster;
            _battleActor = battleActor;
            _ioService = ioService;
            _parenViewModel = parentViewModel;
            battleActor.OneRoundBattle += OnOneRoundBattle;
            battleActor.BattleFinished += OnBattleFinished;
            battleActor.StartBattle(UserBattleState, Monster);
        }

        [Obsolete]
        public BattleViewModel()
        {
            Monster = new MonsterSlime(new MyRandom()) {CurrentHp = 20};
        }

        public int Damage
        {
            get { return _damage; }
            set { SetProperty(ref _damage, value); }
        }

        public bool IsMonsterDamaged
        {
            get { return _isMonsterDamaged; }
            set
            {
                SetProperty(ref _isMonsterDamaged, value);
                OnPropertyChanged(nameof(IsUserDamaged));
            }
        }

        public bool IsUserDamaged => !IsMonsterDamaged;

        public IMonster Monster { get; }
        public UserBattleState UserBattleState { get; }

        private void OnOneRoundBattle(object sender, BattleRoundArgs e)
        {
            IsMonsterDamaged = sender is IMonster;
            Damage = e.Damage;
        }

        private void OnBattleFinished(object sender, BattleFinishedArgs e)
        {
            _battleActor.OneRoundBattle -= OnOneRoundBattle;
            _battleActor.BattleFinished -= OnBattleFinished;

            var view = _ioService.GetView<MonstersView>();
            view.Dispatcher.Invoke(() =>
            {
                view.ViewModel = _parenViewModel;
                _ioService.SwitchView(nameof(MainModule), nameof(MonstersView));
            });
        }
    }
}