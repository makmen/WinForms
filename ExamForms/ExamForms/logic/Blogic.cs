using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using ExamForms.include;

namespace ExamForms.logic
{
    class Blogic
    {
        private DbClass db;

        public Blogic()
        {
            db = new DbClass();
        }

        public Account CheckUser(string login, string password) 
        {
            Account user = new Account("Accounts");
            Dictionary<string, string> result = db.SelectOne("SELECT * FROM Accounts WHERE login = '" + login + "' AND password = '" + password + "'");
            if (result != null && result.Count > 0)
            {
                if (!user.Convert(result))
                {
                    user = null;
                }
            }
            else
            {
                user = null;
            }

            return user;
        }

        public bool IsUniqueField(string field, string value)
        {
            Account user = new Account("Accounts");
            Dictionary<string, string> result = db.SelectOne("SELECT * FROM Accounts WHERE " + field + " = '" + value + "'");
            if (result != null && result.Count > 0)
            {
                if (!user.Convert(result))
                {
                    user = null;
                }
            }
            else
            {
                user = null;
            }
            bool ret = (user == null) ? true : false;

            return ret;
        }

        public List<Account> GetAllAccounts(int group)
        {
            string query; 
            switch (group)
            {
                case 1:
                    query = "SELECT * FROM Accounts";
                    break;
                case 2:
                    query = "SELECT * FROM Accounts WHERE idgroup NOT IN (1)";
                    break;
                default:
                    query = "";
                    break;
            }
            // Account user = new Account("Accounts");
            List<Dictionary<string, string>> result = db.Select(query);
            List<Account> users = new List<Account>();
            Account temp = null;
            for (int i = 0; i < result.Count; ++i)
            {
                if (result[i] != null && result[i].Count > 0)
                {
                    temp = new Account("Accounts");
                    if (temp.Convert(result[i]))
                    {
                        users.Add(temp);
                    }
                }
            }

            return users;
        }

        public Account GetUser(int id)
        {
            Account user = new Account("Accounts");
            Dictionary<string, string> result = db.SelectOne("SELECT * FROM Accounts WHERE id = " + id.ToString());
            if (result != null && result.Count > 0)
            {
                if (!user.Convert(result))
                {
                    user = null;
                }
            }
            else
            {
                user = null;
            }

            return user;
        }

        public bool DeleteUser(int id)
        {
            int result = db.Execute("DELETE FROM Accounts WHERE id = " + id.ToString());
            bool done = (result > 0) ? true : false;

            return done;
        }

        public Account RegisterUser(string name, string firstName, string lastName, DateTime yearBirth, 
            string login, string password, string email, byte [] photo, int idgroup)
        {
            Account user = new Account("Accounts", name, firstName, lastName, yearBirth, login, password, email, photo, idgroup);
            db.CreateCommandInsert(user.InsertString());

            var parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@name";
            parameter.Value = name;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@firstName";
            parameter.Value = firstName;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@lastName";
            parameter.Value = lastName;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@yearBirth";
            parameter.Value = yearBirth;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@login";
            parameter.Value = login;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@password";
            parameter.Value = password;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@email";
            parameter.Value = email;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@photo";
            parameter.Value = photo;
            db.CommandInsert.Parameters.Add(parameter);

            parameter = db.CommandInsert.CreateParameter();
            parameter.ParameterName = "@idgroup";
            parameter.Value = idgroup;
            db.CommandInsert.Parameters.Add(parameter);

            int res = db.Insert();
            if (res <= 0)
            {
                user = null;
            }

            return user;
        }



    }
}
