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
    [Export(typeof (MainPageViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainPageViewModel : BindableBase
    {
        [Import]
        public IUserState UserState { get; private set; }

        public ICommand OpenAchievementsCommand { get; }

        public ICommand OpenAdventuresCommand { get; }

        [ImportingConstructor]
        public MainPageViewModel(IIOService ioService)
        {
            _ioService = ioService;

            OpenAchievementsCommand = new DelegateCommand(() => OpenView(Constants.ACHIEVEMENTS_VIEW));
            OpenAdventuresCommand = new DelegateCommand(() => OpenView(Constants.ADVENTURE_VIEW));
        }

        [Obsolete]
        public MainPageViewModel()
        {
            UserState = new UserState {Gold = 10000, Gem = 200};
        }

        #region Private methods

        private void OpenView(string viewName)
        {
            _ioService.SwitchView(nameof(MainModule), viewName);
        }

        #endregion

        #region Fields

        private readonly IIOService _ioService;

        #endregion
    }
}