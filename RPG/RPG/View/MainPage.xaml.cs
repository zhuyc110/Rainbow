using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     MainPage.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(MainPage))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class MainPage : IView<MainPageViewModel>
    {
        [ImportingConstructor]
        public MainPage()
        {
            InitializeComponent();
        }

        [Import(typeof(MainPageViewModel))]
        public MainPageViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}