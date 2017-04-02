using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// BuyGemView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(BuyGemView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class BuyGemView : IView<BuyGemViewModel>
    {
        [Import]
        public BuyGemViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "购买宝石";

        public BuyGemView()
        {
            InitializeComponent();
        }
    }
}