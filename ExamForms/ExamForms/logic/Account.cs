using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamForms.logic
{
    class Account : Tables
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime YearBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Byte[] Photo { get; set; }
        public int Idgroup { get; set; }

        public Account(string table)
            : base(table)
        {

        }

        public Account(string table, string name_, string firstName_, string lastName_, DateTime yearBirth_,
            string login_, string password_, string email_, Byte[] photo_, int idgroup_)
            : base(table)
        {
            Name = name_;
            FirstName = firstName_;
            LastName = lastName_;
            YearBirth = yearBirth_;
            Login = login_;
            Password = password_;
            Email = email_;
            Photo = photo_;
            Idgroup = idgroup_;
        }

        public string InsertString()
        {
            return "INSERT INTO " + Table + " (name, firstName, lastName, yearBirth, login, password, email, photo, idgroup) OUTPUT INSERTED.id " +
                "VALUES (@name, @firstName, @lastName, @yearBirth, @login, @password, @email, @photo, @idgroup)";
        }

        public bool Convert(Dictionary<string, string> result)
        {
            try
            {
                Id = int.Parse(result["id"]);
                Name = result["name"];
                LastName = result["lastName"];
                FirstName = result["firstName"];
                YearBirth = DateTime.Parse(result["yearBirth"]);
                Login = result["login"];
                Password = result["password"];
                Email = result["email"];
                Photo = Encoding.Unicode.GetBytes(result["photo"]);
                Idgroup = int.Parse(result["idgroup"]);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }


    }
}
