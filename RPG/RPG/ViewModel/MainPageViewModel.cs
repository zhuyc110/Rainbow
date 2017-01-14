using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(MainPageViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainPageViewModel : BindableBase
    {
        private readonly IIOService _ioService;

        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public MainPageViewModel(IIOService ioService, IServiceLocator serviceLocator)
        {
            _ioService = ioService;
            _serviceLocator = serviceLocator;

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
            var view = _serviceLocator.GetInstance<AchievementsViewModel>();
            _ioService.ShowViewModel(view);
        }
    }
}