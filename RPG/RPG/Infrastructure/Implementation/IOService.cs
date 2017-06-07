using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Mvvm;
using Prism.Regions;
using RPG.Infrastructure.Interfaces;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IIOService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IOService : IIOService
    {
        [ImportingConstructor]
        public IOService(IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            _regionManager = regionManager;
            _serviceLocator = serviceLocator;
        }

        #region IIOService Members

        public void ActiveView<TView>(string moduleName)
        {
            var view = _regionManager.Regions[moduleName].Views.OfType<TView>().Single();
            _regionManager.Regions[moduleName].Activate(view);
        }

        public void DeactiveView<TView>(string moduleName)
        {
            var view = _regionManager.Regions[moduleName].Views.OfType<TView>().Single();
            _regionManager.Regions[moduleName].Deactivate(view);
        }

        public TView GetView<TView>()
        {
            return _serviceLocator.GetInstance<TView>();
        }

        public void NavigateBack(string moduleName)
        {
            _regionManager.Regions[moduleName].NavigationService.Journal.GoBack();
        }

        public MessageBoxResult ShowDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButton.YesNo);
        }

        public void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : BindableBase
        {
            var view = _serviceLocator.GetInstance<IView<TViewModel>>();
            view.ViewModel = viewModel;
            ShowView(view);
        }

        public void ShowMessage(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void ShowView<TViewModel>(string moduleName, TViewModel viewModel) where TViewModel : BindableBase
        {
            var view = _serviceLocator.GetInstance<IView<TViewModel>>();
            view.ViewModel = viewModel;
            _regionManager.Regions[moduleName].RequestNavigate(view.GetType().Name);
        }

        public void SwitchView(string moduleName, string viewName)
        {
            _regionManager.Regions[moduleName].RequestNavigate(viewName);
        }

        #endregion

        #region Private methods

        private static void ShowView<TViewModel>(IView<TViewModel> view) where TViewModel : BindableBase
        {
            var window = new Window
            {
                Owner = Application.Current.MainWindow,
                Title = view.Title,
                Content = view,
                Width = 200,
                Height = 300,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            window.ShowDialog();
        }

        #endregion

        #region Fields

        private readonly IRegionManager _regionManager;

        private readonly IServiceLocator _serviceLocator;

        #endregion
    }
}