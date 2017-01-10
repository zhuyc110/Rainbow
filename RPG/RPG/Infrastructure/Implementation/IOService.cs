using RPG.Infrastructure.Interfaces;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IIOService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IOService : IIOService
    {
        public void ShowMessage(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public MessageBoxResult ShowDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButton.YesNo);
        }

        public void ShowView(object view)
        {
            var window = new Window()
            {
                Content = view,
            };
            window.Show();
        }
    }
}