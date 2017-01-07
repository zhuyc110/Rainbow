using System.Windows;

namespace RPG.Infrastructure.Interfaces
{
    public interface IIOService
    {
        MessageBoxResult ShowDialog(string title, string content);
    }
}