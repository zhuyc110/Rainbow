using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    [Export(typeof(IBattleActor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BattleActor : IBattleActor
    {
        public event EventHandler<BattleFinishedArgs> BattleFinished;
        public event EventHandler<BattleRoundArgs> OneRoundBattle;

        #region Properties

        [ImportMany]
        private IEnumerable<EquipmentBase> Equipments { get; set; }

        #endregion

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

        #endregion

        private int CalculateAttack(IBattleEntity battleEntity)
        {
            if (!battleEntity.Skills.Any())
                return battleEntity.CurrentAttack;
            var seed = _random.Next(100);

            foreach (var skill in battleEntity.Skills)
            {
                if (seed < skill.Rate * 100)
                {
                    return (int)(battleEntity.CurrentAttack * skill.AttackRate * skill.AttackFrequency);
                }
            }

            return battleEntity.CurrentAttack;
        }

        private void OnBattleFinished(BattleResult battleResult, IMonster monster)
        {
            var handle = BattleFinished;
            handle?.Invoke(null,
                new BattleFinishedArgs(battleResult == BattleResult.MonsterDied,
                    monster.DropList.ToDictionary(key => key, v => 1), monster.MaximumHp, monster));
        }

        private BattleResult OneRound(IBattleEntity userBattleState, IBattleEntity monster)
        {
            var attack = CalculateAttack(userBattleState);
            monster.CurrentHp = Math.Max(monster.CurrentHp - attack, 0);
            OnOneRoundBattleFinished(monster, attack);
            Thread.Sleep(500);
            if (monster.CurrentHp == 0)
                return BattleResult.MonsterDied;

            var monsterAttack = CalculateAttack(monster);
            userBattleState.CurrentHp = Math.Max(userBattleState.CurrentHp - monsterAttack, 0);
            OnOneRoundBattleFinished(userBattleState, monsterAttack);
            Thread.Sleep(500);
            if (userBattleState.CurrentHp == 0)
                return BattleResult.UserDied;

            return BattleResult.Continue;
        }

        private void OnOneRoundBattleFinished(IBattleEntity damagedEntity, int damage)
        {
            var handle = OneRoundBattle;
            handle?.Invoke(damagedEntity, new BattleRoundArgs(damage));
        }

        #region Fields

        private readonly IRandom _random;

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