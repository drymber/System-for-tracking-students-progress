using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;

namespace StudentsProgress.Repositories
{
    public interface IAnswerRepository
    {
        List<StudentAnswer> GetStudentsAnswer(string studentId, string topicId);
        int AddQuestion(string question, string answer, string topic);
        int AddStudentsAnswer(int studentId, int questionId, bool isCorrect);
        List<Question> GetTopicsQuestion(string topic);
        bool IsTestAlreadyChecked(int studentId, string topic);
    }
}
