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

        #region Private methods

        private void CalculateBattleEntityState(IBattleEntity attackSide, IBattleEntity bearSide, BattleEntityAttack bearSidePreAttack)
        {
            var battleEntityAttack = new BattleEntityAttack(attackSide, _random);
            switch (bearSidePreAttack.SkillEffect)
            {
                case SkillEffect.Dizziness:
                    battleEntityAttack.SkillEffect = SkillEffect.Damage;
                    battleEntityAttack.Damage = 0;
                    break;
                case SkillEffect.Weak:
                    battleEntityAttack.Damage = (int) (battleEntityAttack.Damage * 0.7);
                    break;
                case SkillEffect.Damage:
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
            Thread.Sleep(500);
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