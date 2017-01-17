using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Module;

namespace RPG.ViewModel
{
    [Export(typeof(MainPageViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainPageViewModel : BindableBase
    {
        private readonly IIOService _ioService;

        [ImportingConstructor]
        public MainPageViewModel(IIOService ioService)
        {
            _ioService = ioService;

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
            _ioService.SwitchView(nameof(MainModule),Constants.AchievementsView);
        }
    }
}