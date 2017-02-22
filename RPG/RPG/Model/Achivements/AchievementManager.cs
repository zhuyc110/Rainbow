using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Model.Interfaces;

namespace RPG.Model.Achivements
{
    [Export(typeof(IAchievementManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AchievementManager : IAchievementManager
    {
        public event EventHandler<AchievementEventArgs> OnAchievementGet;

        public ObservableCollection<IAchievement> Achievements { get; set; }

        [ImportingConstructor]
        public AchievementManager([ImportMany]IEnumerable<IAchievement> achievements, IUserState userState)
        {
            _userState = userState;
            Achievements = new ObservableCollection<IAchievement>(achievements);
        }

        private void RecoverAchievements()
        {
            
        }

        private readonly IUserState _userState;
    }
}
