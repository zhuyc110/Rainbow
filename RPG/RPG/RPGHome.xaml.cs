using System.ComponentModel.Composition;

namespace RPG
{
    /// <summary>
    ///     RPGHome.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(RPGHome))]
    public partial class RPGHome
    {
        [ImportingConstructor]
        public RPGHome()
        {
            InitializeComponent();
        }
    }
}