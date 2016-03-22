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
    public class SqlTopicRepository : SqlBaseRepository, ITopicRepository
    {
        public SqlTopicRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #region Methods
        public void DeleteTopic(string topic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spDeleteTopic";
                    command.Parameters.AddWithValue("@title", topic);

                    command.ExecuteNonQuery();
                }
            }
        }
        public int AddTopic(string title)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddTopic";

                    command.Parameters.AddWithValue("@title", title);

                    SqlParameter outputIdParam = new SqlParameter("@topicId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@topicId"].Value;
                }
            }
        }
        public List<Topic> GetTopic()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM tblTopic WHERE IsDeleted <> 1";
                    List<Topic> groups = new List<Topic>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(new Topic((int)reader[0], (string)reader[1]));
                        }
                    }
                    return groups;
                }
            }
        }
        #endregion
    }
}
