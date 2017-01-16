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
    [Export(typeof(NavigationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class NavigationViewModel : BindableBase
    {
        private readonly IIOService _ioService;

        [ImportingConstructor]
        public NavigationViewModel(IIOService ioService)
        {
            _ioService = ioService;

            MainPageCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.MainPage); });
            ChapterCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.UserEquipmentView); });
            BackpackCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.BackpackView); });
            SkillCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.SkillsView); });
            OtherCommand =
                new DelegateCommand(
                    () => { SwitchMainView(Constants.MainPage); });
        }

        [Obsolete]
        public NavigationViewModel()
        {
        }

        public ICommand MainPageCommand { get; }
        public ICommand ChapterCommand { get; }
        public ICommand BackpackCommand { get; }
        public ICommand SkillCommand { get; }
        public ICommand OtherCommand { get; }

        private void SwitchMainView(string viewName)
        {
            _ioService.SwitchView(nameof(MainModule), viewName);
        }
    }
}