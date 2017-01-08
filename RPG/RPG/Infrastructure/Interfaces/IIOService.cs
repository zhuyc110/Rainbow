using System.Windows;

namespace RPG.Infrastructure.Interfaces
{
    public interface IIOService
    {
        void ShowMessage(string title, string content);
        MessageBoxResult ShowDialog(string title, string content);
    }
}