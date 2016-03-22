using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsProgressEntities
{
    public class User
    {
        public User(int id, string firstName, string lastName, string login, string password, bool disabled)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Login = login;
            Password = password;
            Disabled = disabled;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
    }
}
