using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgressEntities
{
    public class StudentAnswer
    {
        public StudentAnswer(int id, int studentId, Question question, bool isCorrect)
        {
            Id = id;
            StudentId = studentId;
            Question = question;
            IsCorrect = isCorrect;
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
