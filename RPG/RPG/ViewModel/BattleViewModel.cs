using System;
using Prism.Mvvm;
using RPG.Infrastructure.Implementation;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Model.Monsters;

namespace RPG.ViewModel
{
    public class BattleViewModel : BindableBase
    {
        public BattleViewModel(UserBattleState userBattleState, IMonster monster)
        {
            UserBattleState = userBattleState;
            Monster = monster;
        }

        [Obsolete]
        public BattleViewModel()
        {
            Monster = new MonsterSlime(new MyRandom()) {CurrentHp = 20};
        }

        public IMonster Monster { get; }
        public UserBattleState UserBattleState { get; }
    }
}