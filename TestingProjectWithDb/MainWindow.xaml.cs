using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace TestingProjectWithDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //#if DEBUG
            //            ctx = new streamlineOrgContext("C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamlineOrgg.sdf");
            //#else
            //            ctx = new streamlineOrgContext(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamlineOrg.sdf");
            //#endif

            //scon = new SqlCeConnection("Data Source=C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamline35.sdf");
            //scon.Open();

            DAL.InitConnection(System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed);

            try
            {
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void TransferDBToLocalAppDataFolder()
        //{
        //    events.Items.Clear();
        //    string localAppData =
        //                Environment.GetFolderPath(
        //                Environment.SpecialFolder.LocalApplicationData);
        //    string userFilePath = Path.Combine(localAppData, "Streamline");
        //    events.Items.Add(userFilePath);
        //    events.Items.Add(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory);

        //    if (File.Exists(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamline35.sdf"))
        //    {
        //        events.Items.Add("postoji DB u data folderu");
        //        if (!Directory.Exists(userFilePath))
        //        {
        //            events.Items.Add("Ne postoji destination folder");
        //            Directory.CreateDirectory(userFilePath);
        //            string sourceFilePath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamline35.sdf";
        //            string destFilePath = Path.Combine(userFilePath, "streamline35.sdf");
        //            File.Move(sourceFilePath, destFilePath);
        //            events.Items.Add("Kopirano uspjesno");
        //            //File.Delete(sourceFilePath);
        //            events.Items.Add("Obrisano uspjesno");
        //        }
        //        else
        //        {
        //            string newFileLocation = Path.Combine(userFilePath, "streamline35.sdf");
        //            if (File.Exists(newFileLocation))
        //            {
        //                events.Items.Add("Postoji vec DB u local app data folderu. Radim kopiju...");
        //                string oldSourceFilePath = newFileLocation;
        //                string oldFileCopyDestFilePath = Path.Combine(userFilePath, "streamline35_Copy.sdf");
        //                File.Move(oldSourceFilePath, oldFileCopyDestFilePath);
        //                events.Items.Add("Kopija napravljena");
        //                //File.Delete(oldSourceFilePath);
        //            }

        //            string sourceFilePath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamline35.sdf";
        //            File.Move(sourceFilePath, newFileLocation);
        //            events.Items.Add("Prebacena DB iz data foldera u local app data folder");
        //            //File.Delete(sourceFilePath);
        //        }
        //    }
        //    else
        //    {
        //        events.Items.Add("Ne postoji DB u data folderu");
        //    }
        //}

        public void RefreshListView()
        {
            listBox1.Items.Clear();
            foreach (Test t in DAL.GetItems())
            {
                listBox1.Items.Add(t.Name);
            }

            listBox1.ScrollIntoView(listBox1.Items[listBox1.Items.Count - 1]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    MessageBox.Show("Transfering DB to app data folder");
            //    TransferDBToLocalAppDataFolder();
            //}
            //else
            //{
            //    MessageBox.Show("Not ClickOnce app");
            //}

            Test newT = new Test();
            newT.Name = textBox1.Text;
            DAL.InsertNewItem(newT);

            RefreshListView();
        }
    }
}
