using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     HeaderView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(HeaderView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class HeaderView : IView<HeaderViewModel>
    {
        public string Title => "标头";

        [Import]
        public HeaderViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public HeaderView()
        {
            InitializeComponent();
        }
    }
}