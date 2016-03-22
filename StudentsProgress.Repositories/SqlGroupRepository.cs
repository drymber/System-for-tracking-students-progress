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
    public class SqlGroupRepository : SqlBaseRepository, IGroupRepository
    {
        public SqlGroupRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #region Methods
        public void DeleteGroup(string group, int year)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteGroup";
                    command.Parameters.AddWithValue("@name", group);
                    command.Parameters.AddWithValue("@year", year.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Group> GetGroup(string year)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, Name FROM tblGroup WHERE IsDeleted <> 1 AND AcademicYear = " + year;
                    List<Group> groups = new List<Group>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(new Group((int)reader[0], (string)reader[1]));
                        }
                    }
                    return groups;
                }
            }
        }

        public List<int> GetAcademicYears()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT DISTINCT AcademicYear FROM tblGroup WHERE IsDeleted <> 1";
                    List<int> years = new List<int>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            years.Add((int)reader[0]);
                        }
                    }
                    return years;
                }
            }
        }
        public int AddGroup(string name, int year)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddGroup";

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@year", year.ToString());

                    SqlParameter outputIdParam = new SqlParameter("@groupId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@groupId"].Value;
                }
            }
        }
        #endregion
    }
}
