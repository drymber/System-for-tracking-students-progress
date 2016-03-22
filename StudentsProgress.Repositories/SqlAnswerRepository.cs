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
    public class SqlAnswerRepository : SqlBaseRepository, IAnswerRepository
    {
        public SqlAnswerRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #region Methods
        public int AddQuestion(string question, string answer, string topic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddQuestion";

                    command.Parameters.AddWithValue("@question", question);
                    command.Parameters.AddWithValue("@answer", answer);
                    command.Parameters.AddWithValue("@topic", topic);

                    SqlParameter outputIdParam = new SqlParameter("@questionId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@questionId"].Value;
                }
            }
        }
        public int AddStudentsAnswer(int studentId, int questionId, bool isCorrect)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spAddStudentsAnswer";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", studentId.ToString());
                    command.Parameters.AddWithValue("@questionId", questionId.ToString());
                    command.Parameters.AddWithValue("@isCorrect", isCorrect.ToString());

                    SqlParameter outputParam = new SqlParameter("@studentAnswerId", System.Data.SqlDbType.Int);
                    outputParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@studentAnswerId"].Value;
                }
            }
        }
        public List<Question> GetTopicsQuestion(string topic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spGetTopicsQuestions";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@topic", topic);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Question> questions = new List<Question>();
                        while (reader.Read())
                        {
                            Question question = new Question((int)reader[0], (string)reader[1], (string)reader[2], (int)reader[3]);
                            questions.Add(question);
                        }
                        return questions;
                    }
                }
            }
        }
        public List<StudentAnswer> GetStudentsAnswer(string studentId, string topic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetInfoAboutStudentsTest";
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@topic", topic);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<StudentAnswer> answers = new List<StudentAnswer>();
                        while (reader.Read())
                        {
                            int questionId = (int)reader[0];
                            string question = (string)reader[1];
                            string answer = (string)reader[2];
                            int topicId = (int)reader[3]; 
                            bool isCorrect = (bool)reader[4];
                            Question q = new Question(questionId, question, answer, topicId);
                            StudentAnswer studentAnswer = new StudentAnswer(1, Convert.ToInt32(studentId), q, isCorrect);
                            answers.Add(studentAnswer);
                        }
                        return answers;
                    }
                }
            }
        }
        public bool IsTestAlreadyChecked(int studentId, string topic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT dbo.fnIsTestAlreadyChecked(@studentId, @topic)";
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@topic", topic);

                    bool result = (bool)command.ExecuteScalar();
                    return result;
                }
            }
        }
        #endregion
    }
}
