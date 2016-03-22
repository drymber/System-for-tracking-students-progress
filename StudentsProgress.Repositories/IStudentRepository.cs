using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;
using System.Data.SqlClient;

namespace StudentsProgress.Repositories
{
    public interface IStudentsRepository
    {
        List<Student> GetStudent(string firstName, string lastName, string group, int year);
        int AddStudent(string firstName, string lastName, string group, string year, string phoneNumber, string email, int age);
        void DeleteStudent(int studentId);
    }
}
