using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Implementation;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Achivements;
using RPG.Model.Battle;
using RPG.Model.Interfaces;
using RPG.Model.Items;
using RPG.Model.Monsters;
using RPG.Module;
using RPG.View;

namespace RPG.ViewModel
{
    public class BattleViewModel : BindableBase
    {
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

        public string TriggeredSkill
        {
            get { return _triggeredSkill; }
            set { SetProperty(ref _triggeredSkill, value); }
        }

        public ICommand FinishBattleCommand { get; }

        public int Gold
        {
            get { return _gold; }
            set { SetProperty(ref _gold, value); }
        }

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

        public IEnumerable<IMonster> Monsters { get; }

        public IMonster BattleMonster
        {
            get { return _battleMonster; }
            set { SetProperty(ref _battleMonster, value); }
        }

        public UserBattleState UserBattleState { get; }

        public SettleViewModel SettleViewModel
        {
            get { return _settleViewModel; }
            set { SetProperty(ref _settleViewModel, value); }
        }

        public BattleViewModel(UserBattleState userBattleState,
            IEnumerable<IMonster> monsters,
            IBattleActor battleActor,
            IIOService ioService,
            IItemManager itemManager,
            IAchievementManager achievementManager)
        {
            IsBattleFinished = false;
            Booties = new ObservableCollection<IItem>();

            FinishBattleCommand = new DelegateCommand(DisposeView);
            UserBattleState = userBattleState;
            Monsters = monsters;
            _battleActor = battleActor;
            _ioService = ioService;
            _itemManager = itemManager;
            _achievementManager = achievementManager;

            SettleViewModel = new SettleViewModel(Enumerable.Empty<IAchievement>());
            _battleActor.OneRoundBattle += OnOneRoundBattle;
            _battleActor.BattleFinished += OnBattleFinished;
            _achievementManager.OnAchievementGet += OnAchievementGet;
        }

        [Obsolete]
        public BattleViewModel()
        {
            Monsters = new[] {new MonsterSlime(new MyRandom()) {CurrentHp = 20}};
            IsBattleFinished = true;
        }

        public async Task StartBattle()
        {
            BattleMonster = Monsters.Single();
            _ioService.DeactiveView<NavigationView>(nameof(NavigationModule));
            await _battleActor.StartBattle(UserBattleState, BattleMonster);
        }

        public async Task StartMultiBattle()
        {
            BattleMonster = Monsters.First();
            _ioService.DeactiveView<NavigationView>(nameof(NavigationModule));
            await _battleActor.StartBattle(UserBattleState, Monsters);
        }

        #region Private methods

        private void DisposeView()
        {
            _achievementManager.OnAchievementGet -= OnAchievementGet;

            SettleViewModel.Achivements.Clear();

            _ioService.ActiveView<NavigationView>(nameof(NavigationModule));
            _ioService.NavigateBack(nameof(MainModule));
        }

        private void OnAchievementGet(object sender, AchievementEventArgs e)
        {
            SettleViewModel = new SettleViewModel(e.Achievements);
        }

        private void OnBattleFinished(object sender, BattleFinishedArgs e)
        {
            IsBattleFinished = true;
            if (e.IsUserVictoried)
            {
                Booties.Clear();

                var booties =
                    _itemManager.AllGameItems.Where(x => e.Items.Keys.Contains(x.ItemName))
                        .Select(x => x.Clone() as ItemBase)
                        .ToList();
                foreach (var booty in booties)
                    booty.Amount = e.Items[booty.ItemName];

                Booties.AddRange(booties);
                UserBattleState.UserState.Gold += e.Gold;
                UserBattleState.UserState.Experience += e.Gold;
                Gold = e.Gold;

                foreach (var itemBase in e.Items)
                    UserBattleState.UserState.ItemManager.AddItem(itemBase.Key, itemBase.Value);
            }

            _battleActor.OneRoundBattle -= OnOneRoundBattle;
            _battleActor.BattleFinished -= OnBattleFinished;
        }

        private void OnOneRoundBattle(object sender, BattleRoundArgs e)
        {
            IsMonsterDamaged = sender is IMonster;
            Damage = e.AttackEntity.Damage;
            if (e.AttackEntity.Skill != null)
            {
                TriggeredSkill = e.AttackEntity.Skill.Name;
            }
            else
            {
                TriggeredSkill = string.Empty;
            }
            var monster = sender as IMonster;
            if (monster != null)
                BattleMonster = monster;
        }

        #endregion

        #region Fields

        private IMonster _battleMonster;

        private string _triggeredSkill;

        private readonly IBattleActor _battleActor;
        private readonly IIOService _ioService;

        private readonly IAchievementManager _achievementManager;
        private readonly IItemManager _itemManager;
        private readonly object _threadLock = new object();
        private ObservableCollection<IItem> _booties;
        private int _damage;
        private int _gold;
        private bool _isBattleFinished;
        private bool _isMonsterDamaged;

        private SettleViewModel _settleViewModel;

        #endregion
    }
}