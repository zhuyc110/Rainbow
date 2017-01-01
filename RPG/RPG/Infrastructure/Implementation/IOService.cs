using RPG.Infrastructure.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IIOService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IOService : IIOService
    {
        public void ShowDialog(string title, string content)
        {
            MessageBox.Show(content, title);
        }
    }
}