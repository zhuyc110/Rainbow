using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;
using RPG.Model.Skills;

namespace RPG.Model.Battle
{
    [Export(typeof(IBattleActor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BattleActor : IBattleActor
    {
        public event EventHandler<BattleFinishedArgs> BattleFinished;
        public event EventHandler<BattleRoundArgs> OneRoundBattle;

        [ImportMany]
        private IEnumerable<EquipmentBase> Equipments { get; set; }

        [ImportingConstructor]
        public BattleActor(IRandom random)
        {
            _random = random;
        }

        #region IBattleActor Members

        public async Task StartBattle(IBattleEntity userBattleState, IMonster monster)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                var result = OneRound(userBattleState, monster);
                while (result == BattleResult.Continue)
                    result = OneRound(userBattleState, monster);
                OnBattleFinished(result, monster);
            });
        }

        public async Task StartBattle(IBattleEntity userBattleState, IEnumerable<IMonster> monsters)
        {
            var monsterList = monsters.ToList();
            var result = new List<BattleResult>();
            foreach (var monster in monsterList)
            {
                var userBattleEntity = userBattleState.NewInstance();
                var oneBattleResult = await Task.Run(() =>
                {
                    Thread.Sleep(500);
                    var x = OneRound(userBattleEntity, monster);
                    while (x == BattleResult.Continue)
                        x = OneRound(userBattleEntity, monster);

                    return x;
                });
                result.Add(oneBattleResult);
                if (oneBattleResult == BattleResult.UserDied)
                    break;
            }
            if (result.Any(x => x == BattleResult.UserDied))
            {
                OnBattleFinished(BattleResult.UserDied, Enumerable.Empty<IMonster>());
            }
            else
            {
                OnBattleFinished(BattleResult.MonsterDied, monsterList);
            }
        }

        #endregion

        #region Private methods

        private void CalculateBattleEntityState(IBattleEntity attackSide, IBattleEntity bearSide, BattleEntityAttack bearSidePreAttack)
        {
            var battleEntityAttack = new BattleEntityAttack(attackSide, _random);
            switch (bearSidePreAttack.SkillEffect)
            {
                case SkillEffect.Dizziness:
                    battleEntityAttack.SkillEffect = SkillEffect.Normal;
                    battleEntityAttack.Damage = 0;
                    break;
                case SkillEffect.Weak:
                    battleEntityAttack.Damage = (int) (battleEntityAttack.Damage * 0.7);
                    break;
                case SkillEffect.Normal:
                case SkillEffect.Dot:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (attackSide is IMonster)
            {
                _monsterPreAttack = battleEntityAttack;
            }
            else
            {
                _userPreAttack = battleEntityAttack;
            }

            bearSide.CurrentHp = Math.Max(bearSide.CurrentHp - battleEntityAttack.Damage, 0);
            OnOneRoundBattleFinished(bearSide, battleEntityAttack);
            if (battleEntityAttack.SkillEffect == SkillEffect.Dot)
            {
                Thread.Sleep(500);
                battleEntityAttack.Damage = (int) (battleEntityAttack.Damage * 0.1);
                OnOneRoundBattleFinished(bearSide, battleEntityAttack);
            }
            Thread.Sleep(500);
        }

        private void OnBattleFinished(BattleResult battleResult, IMonster monster)
        {
            var handle = BattleFinished;
            handle?.Invoke(null,
                new BattleFinishedArgs(battleResult == BattleResult.MonsterDied,
                    monster.DropList.ToDictionary(key => key, v => 1), monster.MaximumHp, new[] {monster}));
        }

        private void OnBattleFinished(BattleResult battleResult, IEnumerable<IMonster> monsters)
        {
            var monsterList = monsters.ToList();
            var items = new Dictionary<string,int>();
            foreach (var dropItem in monsterList.SelectMany(x => x.DropList).Distinct())
            {
                items.Add(dropItem, monsterList.Count(x => x.DropList.Contains(dropItem)));
            }

            var handle = BattleFinished;
            handle?.Invoke(null,
                new BattleFinishedArgs(battleResult == BattleResult.MonsterDied, items, monsterList.Sum(x => x.MaximumHp), monsterList));
        }

        private BattleResult OneRound(IBattleEntity userBattleState, IBattleEntity monster)
        {
            CalculateBattleEntityState(userBattleState, monster, _monsterPreAttack);
            if (monster.CurrentHp == 0)
                return BattleResult.MonsterDied;

            CalculateBattleEntityState(monster, userBattleState, _userPreAttack);
            if (userBattleState.CurrentHp == 0)
                return BattleResult.UserDied;

            return BattleResult.Continue;
        }

        private void OnOneRoundBattleFinished(IBattleEntity damagedEntity, BattleEntityAttack damage)
        {
            var handle = OneRoundBattle;
            handle?.Invoke(damagedEntity, new BattleRoundArgs(damage));
        }

        #endregion

        #region Fields

        private readonly IRandom _random;
        private BattleEntityAttack _monsterPreAttack = new BattleEntityAttack();
        private BattleEntityAttack _userPreAttack = new BattleEntityAttack();

        #endregion

        #region Nested type: BattleResult

        private enum BattleResult
        {
            Continue,
            MonsterDied,
            UserDied
        }

        #endregion
    }
}