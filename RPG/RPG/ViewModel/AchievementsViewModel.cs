using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(AchievementsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AchievementsViewModel : BindableBase
    {
        [ImportMany]
        public ObservableCollection<IAchievement> Achivements { get; set; }
    }
}