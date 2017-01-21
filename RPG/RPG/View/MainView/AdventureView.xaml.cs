using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    ///     AdventureView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(AdventureView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class AdventureView : IView<AdventureViewModel>
    {
        public AdventureView()
        {
            InitializeComponent();
        }

        [Import]
        public AdventureViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "冒险";
    }
}