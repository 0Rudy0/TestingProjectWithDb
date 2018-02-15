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
        private static SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Projects\\TestingProjectWithDb\\TestingProjectWithDb\\streamline35.sdf");
        private static SqlCeCommand cmd = null;
        private static SqlCeDataReader rdr = null;

        public static List<Test> GetItems()
        {
            List<Test> tests = new List<Test>();

            conn.Open();
            cmd = new SqlCeCommand("SELECT * FROM Test", conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Test newt = new Test();
                newt.Id = (int)rdr["Id"];
                newt.Name = (string)rdr["Name"];
            }

            return tests;
        }

        public static bool InsertNewItem(Test newT)
        {
            SqlCeCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Test (Name) VALUES (@name)";
            command.Parameters.Add(new SqlCeParameter("@name", SqlDbType.VarChar)).Value = newT.Name;

            command.ExecuteNonQuery();
            return true;
        }
    }
}
