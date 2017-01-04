using System.Windows;

namespace RPG
{
    /// <summary>
    ///     App.xaml 的交互逻辑
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootStrapper = new BootStrapper();
            bootStrapper.Run();
        }
    }
}