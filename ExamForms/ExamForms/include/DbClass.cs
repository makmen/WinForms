using System;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

using ExamForms.logic;

namespace ExamForms.include
{
    class DbClass
    {
        private DbConnection connection;
        private DbCommand commandInsert;
        public DbCommand CommandInsert
        {
            get { return commandInsert; }
        }
        //private delegate void DisplayInfoDelegate(string Text);
        //private bool isExecuting;
        private string providerName = "System.Data.SqlClient";
        private string strConnection = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=exam; Integrated Security=True;";

        public DbClass()
        {
            connection = null;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                connection = factory.CreateConnection();
                connection.ConnectionString = strConnection;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                connection = null;
            }
        }

        public bool RowExist(string query)
        {
            DbDataReader dataReader = null;
            try
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return true;
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public Dictionary<string, string> SelectOne(string query)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<string> nameFields = new List<string>();
            DbDataReader dataReader = null;
            try
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    for (int i = 0, count = dataReader.VisibleFieldCount; i < count; ++i)
                    {
                        nameFields.Add(dataReader.GetName(i));
                    }
                    for (int i = 0, count = dataReader.VisibleFieldCount; i < count; ++i)
                    {
                        result.Add(nameFields[i], dataReader[i].ToString());
                    }
                    break;
                }
                dataReader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                result = null;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int Insert()
        {
            int result = -1;
            try
            {
                connection.Open();
                result = (int)commandInsert.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public void CreateCommandInsert(string query)
        {
            commandInsert = connection.CreateCommand();
            commandInsert.CommandText = query;
        }

        public List<Dictionary<string, string>> Select(string query)
        {
            List<Dictionary<string, string>> listSelect = new List<Dictionary<string, string>>();
            List<string> nameFields = new List<string>();
            DbDataReader dataReader = null;
            Dictionary<string, string> result = null;
            int numRows = 0;
            try
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (numRows++ == 0)
                    {
                        for (int i = 0, count = dataReader.VisibleFieldCount; i < count; ++i)
                        {
                            nameFields.Add(dataReader.GetName(i));
                        }
                    }
                    result = new Dictionary<string, string>();
                    for (int i = 0, count = dataReader.VisibleFieldCount; i < count; ++i)
                    {
                        result.Add(nameFields[i], dataReader[i].ToString());
                    }
                    listSelect.Add(result);
                }
                dataReader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                result = null;
            }
            finally
            {
                connection.Close();
            }

            return listSelect;
        }

        public int Execute(string query)
        {
            int result = -1;
            try
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
