﻿using System;
using System.Threading.Tasks;
using RPG.Model.Battle;

namespace RPG.Model.Interfaces
{
    public interface IBattleActor
    {
        event EventHandler<BattleFinishedArgs> BattleFinished;
        Task StartBattle(IBattleEntity userBattleState, IBattleEntity monster);
    }
}