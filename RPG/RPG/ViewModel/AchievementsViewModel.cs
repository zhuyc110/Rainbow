using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Achivements;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.ViewModel
{
    [Export(typeof(AchievementsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AchievementsViewModel : BindableBase
    {
        [ImportMany]
        public ObservableCollection<IAchievement> Achivements { get; set; }

        [ImportingConstructor]
        public AchievementsViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                var property = new PropertyAttack(new UserState());
                Achivements = new ObservableCollection<IAchievement>
                {
                    new AchievementFirstBlood(new[] {property}),
                    new AchievementBossKiller(new[] {property}),
                    new AchievementFirstBlood(new[] {property}),
                    new AchievementBossKiller(new[] {property}),
                    new AchievementFirstBlood(new[] {property}),
                    new AchievementBossKiller(new[] {property})
                };
            }
        }
    }
}
