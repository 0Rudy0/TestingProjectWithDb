using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestingProjectWithDb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // This is our connection string: Data Source=|DataDirectory|\Chinook40.sdf
            // Set the data directory to the users %AppData% folder
            // So the Chinook40.sdf file must be placed in:  C:\\Users\\<Username>\\AppData\\Roaming\\
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
}
