using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;
using System.Data.SqlClient;
using System.Data;

namespace StudentsProgress.Repositories
{
    public class SqlStudentRepository : SqlBaseRepository, IStudentsRepository
    {
        public SqlStudentRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #region
        public void DeleteStudent(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteStudent";
                    command.Parameters.AddWithValue("@studentId", studentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetStudent(string firstName, string lastName, string group, int year)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spGetStudents";

                    SqlParameter p1 = new SqlParameter("@firstName", SqlDbType.NVarChar);
                    p1.Value = firstName;
                    command.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("@lastName", SqlDbType.NVarChar);
                    p2.Value = lastName;
                    command.Parameters.Add(p2);

                    SqlParameter p3 = new SqlParameter("@group", SqlDbType.NVarChar);
                    p3.Value = group;
                    command.Parameters.Add(p3);

                    SqlParameter p4 = new SqlParameter("@groupYear", SqlDbType.Int);
                    p4.Value = year;
                    command.Parameters.Add(p4);
                    List<Student> list = new List<Student>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student((int)reader["Id"], (string)reader["FirstName"], (string)reader["LastName"], (string)reader["PhoneNumber"], (string)reader["Email"], (int)reader["Age"], (string)reader["GroupName"]);
                            list.Add(student);
                        }
                    }
                    return list;
                }
            }
        }

        public int AddStudent(string firstName, string lastName, string group, string year, string phoneNumber, string email, int age)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddStudent";

                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@group", group);
                    command.Parameters.AddWithValue("@year", year);

                    SqlParameter pAge = new SqlParameter("@age", SqlDbType.Int);
                    pAge.Value = year;
                    command.Parameters.Add(pAge);

                    SqlParameter outputIdParam = new SqlParameter("@studentId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@studentId"].Value;
                }
            }
        }
        #endregion
    }
}
