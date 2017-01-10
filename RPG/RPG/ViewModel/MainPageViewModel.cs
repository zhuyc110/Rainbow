using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.View;

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

        public ICommand OpenAchievementsCommand { get; }

        private void OpenAchievements()
        {
            var view = _serviceLocator.GetInstance<AchievementsView>();
            _ioService.ShowView(view);
        }
    }
}