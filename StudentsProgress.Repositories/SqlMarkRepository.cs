using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;
using System.Data.SqlClient;

namespace StudentsProgress.Repositories
{
    public class SqlMarkRepository : SqlBaseRepository, IMarkRepository
    {
        public SqlMarkRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #region
        public int AddMark(int studentId, int topicId, decimal mark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spAddMark";

                    command.Parameters.AddWithValue("@studentId", studentId.ToString());
                    command.Parameters.AddWithValue("@topicId", topicId.ToString());
                    command.Parameters.AddWithValue("@mark", mark.ToString());

                    SqlParameter outputParam = new SqlParameter("@markId", System.Data.SqlDbType.Int);
                    outputParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@markId"].Value;
                }
            }
        }
        public List<Mark> GetMarks(string studentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spGetMarks";
                    command.Parameters.AddWithValue("@studentId", studentId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Mark> marks = new List<Mark>();
                        while (reader.Read())
                        {
                            marks.Add(new Mark((int)reader[0], Convert.ToInt32(studentId), (string)reader[1], (decimal)reader[2]));
                        }
                        return marks;
                    }

                }
            }
        }
        #endregion
    }
}
