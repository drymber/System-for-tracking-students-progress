using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using StudentsProgressEntities;
using StudentsProgress.Repositories;
using StudentsProgressManager.Code;

namespace StudentsProgressManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region Methods
        private void ShowStudents(string firstName, string lastName, string group, int year, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            SqlStudentRepository st = new SqlStudentRepository(Program.ConnectionString);
            List<Student> students = st.GetStudent(firstName, lastName, group, year);

            foreach (Student student in students)
            {
                string[] row = { student.FirstName, student.LastName, student.Group, student.PhoneNumber, student.Email, student.Age.ToString() };
                dataGridViewStudents.Rows.Add(row);
            }
        }
        private void ShowStudentAnswerToGrid()
        {
            if (comboBoxTopic.SelectedItem != null && comboBoxGroupTest.SelectedItem != null && comboBoxYearForTests.SelectedItem != null && comboBoxStudent.SelectedItem != null)
            {
                string topic = comboBoxTopic.SelectedItem.ToString();
                Student student = Program.GetStudentFromComboBox(comboBoxStudent, comboBoxYearForTests, comboBoxGroupTest);

                dataGridAnswers.Rows.Clear();
                SqlAnswerRepository answerRepository = new SqlAnswerRepository(Program.ConnectionString);
                List<StudentAnswer> answers = answerRepository.GetStudentsAnswer(student.Id.ToString(), topic);
                foreach (StudentAnswer answer in answers)
                {
                    dataGridAnswers.Rows.Add(answer.Question.QuestionSentence, answer.Question.Answer, answer.IsCorrect.ToString());
                }

                dataGridMarks.Rows.Clear();
                SqlMarkRepository markRepository = new SqlMarkRepository(Program.ConnectionString);
                List<Mark> marks = markRepository.GetMarks(student.Id.ToString());
                foreach (Mark mark in marks)
                {
                    dataGridMarks.Rows.Add(mark.Topic, mark.Value);
                }
            }
        }
        private void ShowAnswers(string studentId, string topic, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            SqlAnswerRepository answerRepository = new SqlAnswerRepository(Program.ConnectionString);
            List<StudentAnswer> answers = answerRepository.GetStudentsAnswer(studentId, topic);
            foreach (StudentAnswer answer in answers)
            {
                dataGridView.Rows.Add(answer.Question.QuestionSentence, answer.Question.Answer, answer.IsCorrect.ToString());
            }
        }
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            labelUser.Text = String.Format("{0} {1}", CurrentUser.FirstName, CurrentUser.LastName);
            Program.ShowYearsToCombo(comboBoxYearStudent);
            Program.ShowGroupsToComboBox(comboBoxGroupStudent, comboBoxYearStudent);
            Program.ShowYearsToCombo(comboBoxYearForTests);
            Program.ShowGroupsToComboBox(comboBoxGroupTest, comboBoxYearForTests);
            Program.ShowStudentsToCombo("", "", comboBoxGroupTest.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearForTests.SelectedItem), comboBoxStudent);
            Program.ShowTopicsToCombobox(comboBoxTopic);
        }

        private void buttonFindStudent_Click(object sender, EventArgs e)
        {
            string firstName = textBoxName.Text;
            string lastName = textBoxSurname.Text;
            string groupName = comboBoxGroupStudent.SelectedItem.ToString();
            int year = Convert.ToInt32(comboBoxYearStudent.SelectedItem);
            ShowStudents(firstName, lastName, groupName, year, dataGridViewStudents);
        }
        private void comboBoxTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudentAnswerToGrid();
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowStudentsToCombo("", "", comboBoxGroupTest.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearForTests.SelectedItem), comboBoxStudent);
        }

        private void numericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            comboBoxStudent.Items.Clear();
            comboBoxStudent.Text = "";
            Program.ShowStudentsToCombo("", "", comboBoxGroupTest.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearForTests.SelectedItem), comboBoxStudent);
        }

        private void comboBoxYearStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroupStudent, comboBoxYearStudent);
        }

        private void comboBoxYearForTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroupTest, comboBoxYearForTests);
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudentAnswerToGrid();
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            if (addStudent.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void newTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTopic addTopic = new AddTopic();
            addTopic.ShowDialog();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnswerParams addAnswerParams = new AddAnswerParams();
            if (addAnswerParams.ShowDialog() == DialogResult.OK)
            {

            }
        }
        
        private void insertInfoToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            menuStrip1.Items[0].ForeColor = Color.Black;
        }

        private void insertInfoToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            menuStrip1.Items[0].ForeColor = Color.White;
        }

        private void newGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGroup addGroup = new AddGroup();
            addGroup.ShowDialog();
        }

        private void newQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQuestions addQuestion = new AddQuestions();
            addQuestion.ShowDialog();
        }

        private void deleteDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData deleteData = new DeleteData();
            deleteData.ShowDialog();
        }
        #endregion
    }
}
