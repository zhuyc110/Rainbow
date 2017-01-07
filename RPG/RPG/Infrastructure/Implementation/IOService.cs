﻿using RPG.Infrastructure.Interfaces;
using System.ComponentModel.Composition;
using System.Windows;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IIOService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IOService : IIOService
    {
        public MessageBoxResult ShowDialog(string title, string content)
        {
            return MessageBox.Show(content, title, MessageBoxButton.YesNo);
        }
    }
}