using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RPG.Model.Equipment;
using RPG.Model.Interfaces;
using RPG.Model.Items;

namespace RPG.Model.Battle
{
    [Export(typeof(IBattleActor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BattleActor : IBattleActor
    {
        #region Properties

        [ImportMany]
        private IEnumerable<EquipmentBase> Equipments { get; set; }

        [ImportMany]
        private IEnumerable<ItemBase> Items { get; set; }

        #endregion

        #region IBattleActor Members

        public event EventHandler<BattleFinishedArgs> BattleFinished;
        public event EventHandler<BattleRoundArgs> OneRoundBattle;

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

        private BattleResult OneRound(IBattleEntity userBattleState, IBattleEntity monster)
        {
            OnOneRoundBattleFinished(monster, userBattleState.CurrentAttack);
            monster.CurrentHp = Math.Max(monster.CurrentHp - userBattleState.CurrentAttack, 0);
            Thread.Sleep(500);
            if (monster.CurrentHp == 0)
                return BattleResult.MonsterDied;

            OnOneRoundBattleFinished(userBattleState, monster.CurrentAttack);
            userBattleState.CurrentHp = Math.Max(userBattleState.CurrentHp - monster.CurrentAttack, 0);
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

        private void OnBattleFinished(BattleResult battleResult, IMonster monster)
        {
            IEnumerable<IItem> dropList = Items.Where(x => monster.DropList.Contains(x.ItemName));

            var handle = BattleFinished;
            handle?.Invoke(null,
                new BattleFinishedArgs(battleResult == BattleResult.MonsterDied, dropList, monster.MaximumHp));
        }

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