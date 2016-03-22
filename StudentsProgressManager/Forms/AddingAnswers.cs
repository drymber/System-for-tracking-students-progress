using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentsProgressEntities;
using StudentsProgress.Repositories;
using System.Configuration;

namespace StudentsProgressManager
{
    public partial class AddingAnswers : Form
    {
        private List<Question> _questions = new List<Question>();
        private List<StudentAnswer> _studentAnswers = new List<StudentAnswer>();
        private int _number = 0;
        private int _studentId = 0;
        public AddingAnswers(List<Question> questions, int studentId)
        {
            InitializeComponent();
            _questions = questions;
            textBoxQuestion.Text = _questions[0].QuestionSentence;
            _studentId = studentId;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_number < _questions.Count)
            {
                _studentAnswers.Add(new StudentAnswer(_number, _studentId, _questions[_number], radioButtonCorrect.Checked));
                textBoxQuestion.Text = _questions[_number].QuestionSentence;
                _number++;
                labelNumber.Text = String.Format("{0}.", _number + 1);
            }
            else
            {
                SqlAnswerRepository answerRep = new SqlAnswerRepository(Program.ConnectionString);
                foreach (StudentAnswer studentAnswer in _studentAnswers)
                {
                    answerRep.AddStudentsAnswer(studentAnswer.StudentId, studentAnswer.Question.Id, studentAnswer.IsCorrect);
                }

                SqlMarkRepository markRep = new SqlMarkRepository(Program.ConnectionString);
                decimal mark = (decimal)_studentAnswers.Where(sa => sa.IsCorrect).Count() / (decimal)_studentAnswers.Count * 100;
                //int mark = _studentAnswers.Where(sa => sa.IsCorrect).Count();
                markRep.AddMark(_studentId, _questions[0].TopicId, mark);

                MessageBox.Show("The data have been successfully added!");
                Close();
            }
        }
    }
}
