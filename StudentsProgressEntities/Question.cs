using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgressEntities
{
    public class Question
    {
        public Question(int id, string questionSentence, string answer, int topicId)
        {
            Id = id;
            QuestionSentence = questionSentence;
            Answer = answer;
            TopicId = topicId;
        }

        public int Id { get; set; }
        public string QuestionSentence { get; set; }
        public string Answer { get; set; }
        public int TopicId { get; set; }
    }
}
