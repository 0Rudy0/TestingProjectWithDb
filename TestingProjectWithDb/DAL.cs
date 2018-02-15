using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProjectWithDb
{
    public static class DAL
    {
        private static SqlCeConnection conn;
        private static SqlCeCommand cmd = null;
        private static SqlCeDataReader rdr = null;

        public static void InitConnection(bool isClickOnce)
        {
            if (isClickOnce)
            {
                conn = new SqlCeConnection("Data Source=" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\streamline35.sdf");
            }
            else
            {
                conn = new SqlCeConnection("Data Source=C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamline35.sdf");

            }
        }

        public static List<Test> GetItems()
        {
            List<Test> tests = new List<Test>();

            conn.Open();
            cmd = new SqlCeCommand("SELECT * FROM Test", conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Test newt = new Test();
                newt.Id = (int)rdr["id"];
                newt.Name = (string)rdr["name"];
                tests.Add(newt);
            }

            //conn.Dispose();
            conn.Close();
            return tests;
        }

        public static bool InsertNewItem(Test newT)
        {
            conn.Open();
            cmd = conn.CreateCommand();
            //SqlCeCommand command = new SqlCeCommand("INSERT INTO Test(name) VALUES(@name)", conn);
            cmd.CommandText = "INSERT INTO Test (name) VALUES (@name)";
            cmd.Parameters.Add(new SqlCeParameter("@name", SqlDbType.NVarChar)).Value = newT.Name;

            cmd.ExecuteNonQuery();
            //conn.Dispose();
            conn.Close();
            return true;
        }
    }
}
