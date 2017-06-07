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

        public ICommand OpenDuplicationsCommand { get; }

        public ICommand OpenBuyGemCommand { get; }

        public ICommand OpenBonusCommand { get; }

        public ICommand OpenAnnouncementCommand { get; }

        public ICommand OpenTipCommand { get; }

        [ImportingConstructor]
        public MainPageViewModel(IIOService ioService)
        {
            _ioService = ioService;

            OpenAchievementsCommand = new DelegateCommand(() => OpenView(Constants.ACHIEVEMENTS_VIEW));
            OpenAdventuresCommand = new DelegateCommand(() => OpenView(Constants.ADVENTURE_VIEW));
            OpenBuyGemCommand = new DelegateCommand(() => OpenView(Constants.BUYGEM_VIEW));
            OpenBonusCommand = new DelegateCommand(() => OpenView(Constants.BONUS_VIEW));
            OpenAnnouncementCommand = new DelegateCommand(() => ioService.ShowMessage("公告", "这是一个公告"));
            OpenTipCommand = new DelegateCommand(() => ioService.ShowMessage("提示", "这是一个提示"));
            OpenDuplicationsCommand = new DelegateCommand(() => OpenView(Constants.DUPLICATIONS_VIEW));
        }

        [Obsolete]
        public MainPageViewModel()
        {
            UserState = new UserState {Gold = 10000, Gem = 200};
        }

        #region Private methods

        private void OpenView(string viewName)
        {
            _ioService.SwitchView(Constants.MAIN_REGION, viewName);
        }

        #endregion

        #region Fields

        private readonly IIOService _ioService;

        #endregion
    }
}