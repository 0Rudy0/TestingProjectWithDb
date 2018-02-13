using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
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
        SqlCeConnection sqlConnection1;
        streamlineOrgContext ctx = new streamlineOrgContext("streamlineOrg.sdf");
        public MainWindow()
        {
            InitializeComponent();
            //sqlConnection1 = new SqlCeConnection();
            //sqlConnection1.ConnectionString = "Data Source = C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamline.sdf;Persist Security Info=False";
            //sqlConnection1.Open();
            //getData();
            RefreshListView();
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

        //public void getData()
        //{

        //    string SqlCeCommandGetMovies = "SELECT * FROM [Test]";
        //    SqlCeCommand command = new SqlCeCommand(SqlCeCommandGetMovies, sqlConnection1);
        //    SqlCeDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        MessageBox.Show((string)reader["name"]);
        //    }
        //}

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
