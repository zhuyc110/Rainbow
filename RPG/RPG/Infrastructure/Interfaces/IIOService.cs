using System.Windows;
using Prism.Mvvm;

namespace RPG.Infrastructure.Interfaces
{
    public interface IIOService
    {
        void ShowMessage(string title, string content);
        MessageBoxResult ShowDialog(string title, string content);
        void ShowViewModel<TViewModel>(TViewModel viewModel) where TViewModel : BindableBase;
    }
}