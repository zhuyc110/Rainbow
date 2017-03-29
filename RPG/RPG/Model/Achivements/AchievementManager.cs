using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using RPG.Model.Battle;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    [Export(typeof(IAchievementManager))]
    [Export(typeof(ISavableData))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AchievementManager : IAchievementManager, ISavableData
    {
        public event EventHandler<AchievementEventArgs> OnAchievementGet;


        public ObservableCollection<IAchievement> Achievements { get; set; }


        [ImportingConstructor]
        public AchievementManager([ImportMany] IEnumerable<IAchievement> achievements, IUserState userState,
            IBattleActor battleActor)
        {
            _userState = userState;
            Achievements = new ObservableCollection<IAchievement>(achievements);
            RecoverAchievements();
            battleActor.BattleFinished += OnBattleFinished;
        }

        #region ISavableData Members

        public void SaveData()
        {
            _userState.Achievements = Achievements.Select(x => new AchievementExtract(x.Name, x.Current)).ToList();
        }

        #endregion

        #region Private methods

        private void OnBattleFinished(object sender, BattleFinishedArgs e)
        {
            var achievements = new List<IAchievement>();
            foreach (var achievement in Achievements.Where(x => x.CanHandleEvent(e)))
            {
                achievement.HandleEvent();
                if (achievement.Achived)
                {
                    achievements.Add(achievement);
                }
            }
            RaiseAchievementGet(achievements);
        }

        private void RaiseAchievementGet(IEnumerable<IAchievement> achievement)
        {
            var handle = OnAchievementGet;
            handle?.Invoke(this, new AchievementEventArgs(achievement));
        }

        private void RecoverAchievements()
        {
            foreach (var achievementExtract in _userState.Achievements)
            {
                var matchedAchievement = Achievements.FirstOrDefault(x => x.Name == achievementExtract.Name);
                if (matchedAchievement == null)
                {
                    Log.Error($"Can not find achievement: {achievementExtract.Name}");
                    continue;
                }
                matchedAchievement.Current = achievementExtract.Current;
            }
        }

        #endregion

        #region Fields

        private static readonly ILog Log = LogManager.GetLogger(typeof(AchievementManager));

        private readonly IUserState _userState;

        #endregion
    }
}