﻿using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using RPG.Model.Interfaces;

namespace RPG.Model.Battle
{
    [Export(typeof(IBattleActor))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BattleActor : IBattleActor
    {
        public event EventHandler<BattleFinishedArgs> BattleFinished;

        public async Task StartBattle(IBattleEntity userBattleState, IBattleEntity monster)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                var result = OneRound(userBattleState, monster);
                while (result == BattleResult.Continue)
                    result = OneRound(userBattleState, monster);
                OnBattleFinished(result);
            });
        }

        public event EventHandler<BattleRoundArgs> OneRoundBattle;

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

        private void OnBattleFinished(BattleResult battleResult)
        {
            var handle = BattleFinished;
            handle?.Invoke(null, new BattleFinishedArgs(battleResult == BattleResult.MonsterDied, null, 0));
        }

        private enum BattleResult
        {
            Continue,
            MonsterDied,
            UserDied
        }
    }
}