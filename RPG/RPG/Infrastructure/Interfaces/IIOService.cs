using System.Windows;
using Prism.Mvvm;

namespace RPG.Infrastructure.Interfaces
{
    public interface IIOService
    {
        void ShowMessage(string title, string content);
        MessageBoxResult ShowDialog(string title, string content);
        void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : BindableBase;

        TView GetView<TView>();
        void DeactiveView<TView>(string moduleName);
        void ActiveView<TView>(string moduleName);

        void SwitchView(string moduleName, string viewName);
        void ShowView<TViewModel>(string moduleName, TViewModel viewModel) where TViewModel : BindableBase;

        void NavigateBack(string moduleName);
    }
}