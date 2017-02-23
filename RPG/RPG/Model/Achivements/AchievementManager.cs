using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    [Export(typeof(IAchievementManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AchievementManager : IAchievementManager
    {
        public event EventHandler<AchievementEventArgs> OnAchievementGet;

        #region Properties

        public ObservableCollection<IAchievement> Achievements { get; set; }

        #endregion

        [ImportingConstructor]
        public AchievementManager([ImportMany] IEnumerable<IAchievement> achievements, IUserState userState)
        {
            _userState = userState;
            Achievements = new ObservableCollection<IAchievement>(achievements);
            RecoverAchievements();
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

        #region Fields

        private static readonly ILog Log = LogManager.GetLogger(typeof(AchievementManager));

        private readonly IUserState _userState;
        public void SaveData()
        {
            _userState.Achievements = Achievements.Select(x => new AchievementExtract(x.Name, x.Current)).ToList();
        }

        #endregion
    }
}