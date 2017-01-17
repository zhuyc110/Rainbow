using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using Prism.Mvvm;
using RPG.View.MainView;

namespace RPG.ViewModel
{
    [Export(typeof(BackpackViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BackpackViewModel : BindableBase
    {
        [ImportingConstructor]
        public BackpackViewModel(IServiceLocator serviceLocator)
        {
            Tabs = new ObservableCollection<TabItem>
            {
                new TabItem {Header = "装备", Content = serviceLocator.GetInstance<EquipmentView>()},
                new TabItem {Header = "物品", Content = serviceLocator.GetInstance<ItemsView>()}
            };
        }

        public ObservableCollection<TabItem> Tabs { get; set; }
    }
}