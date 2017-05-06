using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SqlFactories
{
    class DbClass
    {
        private DbConnection connection;
        private string strConnection;
        private string providerName;

        public DbConnection Connection
        {
            get { return connection; }
        }

        public DbClass()
        {
            providerName = "System.Data.SqlClient";
            strConnection = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=persons; Integrated Security=True;";
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                connection = factory.CreateConnection();
                connection.ConnectionString = strConnection;
                connection.Open();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                connection = null;
            }
        }

        public void Select(string sql)
        {
            if (connection != null && sql != "")
            {
                DbCommand command = connection.CreateCommand();
                try
                {
                    command.CommandText = sql;

                   // int res = command.ExecuteReader();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        public int ExecuteDbCommand(string sql)
        {
            int res = -1;
            if (connection != null && sql != "")
            {
                DbCommand command = connection.CreateCommand();
                try
                {
                    command.CommandText = sql;
                    res = command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

            return res;
        }



    }
}
