using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TestingProjectWithDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        streamlineOrgContext ctx;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            ctx = new streamlineOrgContext("C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamlineOrg.sdf");
#else
            ctx = new streamlineOrgContext(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamlineOrg.sdf");
#endif
            try
            {
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshListView()
        {
            listBox1.Items.Clear();
            foreach (Test t in ctx.Test.ToList())
            {
                listBox1.Items.Add(t.Name);
            }

            listBox1.ScrollIntoView(listBox1.Items[listBox1.Items.Count - 1]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test newT = new Test();
            newT.Name = textBox1.Text;
            ctx.Test.InsertOnSubmit(newT);
            ctx.SubmitChanges();

            RefreshListView();
        }
    }
}
