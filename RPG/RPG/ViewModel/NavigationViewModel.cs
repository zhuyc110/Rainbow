using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure;
using RPG.Infrastructure.Interfaces;
using RPG.Module;

namespace RPG.ViewModel
{
    [Export(typeof (NavigationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class NavigationViewModel : BindableBase
    {
        public ICommand MainPageCommand { get; }
        public ICommand ChapterCommand { get; }
        public ICommand BackpackCommand { get; }
        public ICommand SkillCommand { get; }
        public ICommand OtherCommand { get; }

        [ImportingConstructor]
        public NavigationViewModel(IIOService ioService)
        {
            _ioService = ioService;

            MainPageCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.MAIN_PAGE); });
            ChapterCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.USER_EQUIPMENT_VIEW); });
            BackpackCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.BACKPACK_VIEW); });
            SkillCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.SKILLS_VIEW); });
            OtherCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.MAIN_PAGE); });
        }

        [Obsolete]
        public NavigationViewModel()
        {
        }

        #region Private methods

        private void SwitchMainView(string viewName)
        {
            _ioService.SwitchView(nameof(MainModule), viewName);
        }

        #endregion

        #region Fields

        private readonly IIOService _ioService;

        #endregion
    }
}