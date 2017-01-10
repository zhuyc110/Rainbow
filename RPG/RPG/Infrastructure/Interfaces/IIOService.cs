using System.Windows;
using System.Windows.Controls;

namespace RPG.Infrastructure.Interfaces
{
    public interface IIOService
    {
        void ShowMessage(string title, string content);
        MessageBoxResult ShowDialog(string title, string content);
        void ShowView(object view);
    }
}