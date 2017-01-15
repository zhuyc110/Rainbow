using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RPG.Module;
using RPG.View;

namespace RPG.ViewModel
{
    [Export(typeof(NavigationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class NavigationViewModel : BindableBase
    {
        [ImportingConstructor]
        public NavigationViewModel(IRegionManager regionManager)
        {
            MainPageCommand =
                new DelegateCommand(
                    () => { regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(MainPage)); });
            ChapterCommand =
                new DelegateCommand(
                    () => { regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(UserEquipmentView)); });
            BackpackCommand =
                new DelegateCommand(
                    () => { regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(BackpackView)); });
            SkillCommand =
                new DelegateCommand(
                    () => { regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(SkillsView)); });
            OtherCommand =
                new DelegateCommand(
                    () => { regionManager.Regions[nameof(MainModule)].RequestNavigate(nameof(MainPage)); });
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
    }
}