using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;
using log4net;
using Prism.Mef;
using RPG.Infrastructure.Implementation;
using RPG.Model;
using RPG.Model.Interfaces;

namespace RPG
{
    public class BootStrapper : MefBootstrapper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(BootStrapper));

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<RpgHome>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(BootStrapper).Assembly));
        }

        protected override void ConfigureContainer()
        {
            IUserState userData = null;
            if (File.Exists("UserData.dat"))
            {
                try
                {
                    userData = XmlSerializer.Instance.DeSerialize<UserState>("UserData.dat");
                    Log.Info("UserData is loaded from file.");
                }
                catch (Exception exception)
                {
                    Log.Info("UserData can not be loaded from file.", exception);
                }
            }
            if (userData == null)
            {
                userData = new UserState();
                Log.Info("New UserData is created.");
            }
            Container.ComposeExportedValue(userData);

            Container.ComposeExportedValue(XmlSerializer.Instance);
            base.ConfigureContainer();
        }
    }
}