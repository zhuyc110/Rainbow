using RPG.Infrastructure.Interfaces;
using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Mvvm;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IIOService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IOService : IIOService
    {
        [Import]
        private IServiceLocator ServiceLocator { get; set; }

        public void ShowMessage(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public MessageBoxResult ShowDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButton.YesNo);
        }

        public void ShowViewModel<TViewModel>(TViewModel viewModel) where TViewModel : BindableBase
        {
            var view = ServiceLocator.GetInstance<IView<TViewModel>>();
            ShowView(view);
        }

        private static void ShowView<TViewModel>(IView<TViewModel> view) where TViewModel : BindableBase
        {
            var window = new Window
            {
                Title = view.Title,
                Content = view,
                Width = 400,
                Height = 600
            };
            window.Show();
        }
    }
}