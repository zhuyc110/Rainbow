using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Module;
using RPG.View;

namespace RPG.ViewModel
{
    [Export(typeof(MainPageViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainPageViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public MainPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            OpenAchievementsCommand = new DelegateCommand(OpenAchievements);
        }

        [Obsolete]
        public MainPageViewModel()
        {
            UserState = new UserState {Gold = 10000, Gem = 200};
        }

        [Import]
        public IUserState UserState { get; private set; }

        public ICommand OpenAchievementsCommand { get; }

        private void OpenAchievements()
        {
            _regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(AchievementsView));
        }
    }
}