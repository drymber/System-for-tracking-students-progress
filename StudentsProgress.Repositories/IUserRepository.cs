using StudentsProgressEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgress.Repositories
{
    interface IUserRepository
    {
        User GetUserByLogin(string login, string password);
    }
}
