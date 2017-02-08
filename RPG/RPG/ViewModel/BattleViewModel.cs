using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
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
    public class BattleViewModel : BindableBase
    {
        #region Fields

        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;
        private readonly MonstersViewModel _parenViewModel;
        private readonly object _threadLock = new object();
        private ObservableCollection<IItem> _booties;
        private int _damage;
        private bool _isBattleFinished;
        private bool _isMonsterDamaged;

        #endregion

        #region Properties

        public ObservableCollection<IItem> Booties
        {
            get { return _booties; }
            private set
            {
                _booties = value;
                BindingOperations.EnableCollectionSynchronization(_booties, _threadLock);
            }
        }

        public int Damage
        {
            get { return _damage; }
            set { SetProperty(ref _damage, value); }
        }

        public ICommand FinishBattleCommand { get; }

        public bool IsBattleFinished
        {
            get { return _isBattleFinished; }
            set { SetProperty(ref _isBattleFinished, value); }
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

        #endregion

        public BattleViewModel(UserBattleState userBattleState, IMonster monster, IBattleActor battleActor,
            IIOService ioService, MonstersViewModel parentViewModel)
        {
            IsBattleFinished = false;
            Booties = new ObservableCollection<IItem>();

            FinishBattleCommand = new DelegateCommand(DisposeView);
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
            IsBattleFinished = true;
        }

        private void OnOneRoundBattle(object sender, BattleRoundArgs e)
        {
            IsMonsterDamaged = sender is IMonster;
            Damage = e.Damage;
        }

        private void OnBattleFinished(object sender, BattleFinishedArgs e)
        {
            IsBattleFinished = true;
            if (e.IsUserVictoried)
            {
                Booties.Clear();
                Booties.AddRange(e.Items);
                UserBattleState.UserState.Gold += e.Gold;
            }

            _battleActor.OneRoundBattle -= OnOneRoundBattle;
            _battleActor.BattleFinished -= OnBattleFinished;
        }

        private void DisposeView()
        {
            var view = _ioService.GetView<MonstersView>();
            view.Dispatcher.Invoke(() =>
            {
                view.ViewModel = _parenViewModel;
                _ioService.SwitchView(nameof(MainModule), nameof(MonstersView));
            });
        }
    }
}