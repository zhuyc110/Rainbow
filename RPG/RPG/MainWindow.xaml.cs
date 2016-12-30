using System.ComponentModel.Composition;

namespace RPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export(typeof(MainWindow))]
    public partial class MainWindow
    {
        [ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}