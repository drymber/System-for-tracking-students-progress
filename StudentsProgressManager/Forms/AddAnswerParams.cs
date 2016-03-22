using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentsProgress.Repositories;
using System.Configuration;
using StudentsProgressEntities;

namespace StudentsProgressManager
{
    public partial class AddAnswerParams : Form
    {
        public AddAnswerParams()
        {
            InitializeComponent();
            Program.ShowYearsToCombo(comboBoxYear);
            Program.ShowGroupsToComboBox(comboBoxGroup, comboBoxYear);
            Program.ShowStudentsToCombo("", "", comboBoxGroup.SelectedItem.ToString(), Convert.ToInt32(comboBoxYear.SelectedItem.ToString()), comboBoxStudent);
            Program.ShowTopicsToCombobox(comboBoxTopic);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SqlAnswerRepository answerRep = new SqlAnswerRepository(Program.ConnectionString);
            Student student = Program.GetStudentFromComboBox(comboBoxStudent, comboBoxYear, comboBoxGroup);
            string topic = comboBoxTopic.SelectedItem.ToString();
            bool alreadyExist = answerRep.IsTestAlreadyChecked(student.Id, topic);
            
            if (!alreadyExist)
            {
                List<Question> questions = answerRep.GetTopicsQuestion(topic);
                AddingAnswers a = new AddingAnswers(questions, student.Id);
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Already checked!");
            }
        }
        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroup, comboBoxYear);
        }
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowStudentsToCombo("", "", comboBoxGroup.SelectedItem.ToString(), Convert.ToInt32(comboBoxYear.SelectedItem.ToString()), comboBoxStudent);
        }
    }
}
