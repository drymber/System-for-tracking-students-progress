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
using StudentsProgressEntities;

namespace StudentsProgressManager
{
    public partial class DeleteData : Form
    {
        public DeleteData()
        {
            InitializeComponent();
            Program.ShowYearsToCombo(comboBoxYearDeleteStudent);
            Program.ShowGroupsToComboBox(comboBoxGroupDeleteStudent, comboBoxYearDeleteStudent);
            Program.ShowStudentsToCombo("", "", comboBoxGroupDeleteStudent.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearDeleteStudent.SelectedItem.ToString()), comboBoxStudentDeleteStudent);

            Program.ShowYearsToCombo(comboBoxYearDeleteGroup);
            Program.ShowGroupsToComboBox(comboBoxGroupDeleteGroup, comboBoxYearDeleteGroup);

            Program.ShowTopicsToCombobox(comboBoxTopicDeleteTopic);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlStudentRepository studentRep = new SqlStudentRepository(Program.ConnectionString);
            Student student = Program.GetStudentFromComboBox(comboBoxStudentDeleteStudent, comboBoxYearDeleteStudent, comboBoxGroupDeleteStudent);
            if (MessageBox.Show("Are you sure you want delete this this student from the database?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                studentRep.DeleteStudent(student.Id);
                MessageBox.Show("Student's data have been successfully deleted.");
                Program.ShowStudentsToCombo("", "", comboBoxGroupDeleteStudent.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearDeleteStudent.SelectedItem.ToString()), comboBoxStudentDeleteStudent);
            }
        }

        private void comboBoxYearDeleteStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroupDeleteStudent, comboBoxYearDeleteStudent);
        }

        private void comboBoxGroupDeleteStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowStudentsToCombo("", "", comboBoxGroupDeleteStudent.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearDeleteStudent.SelectedItem.ToString()), comboBoxStudentDeleteStudent);
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            SqlGroupRepository groupRep = new SqlGroupRepository(Program.ConnectionString);
            if (MessageBox.Show("Are you sure you want delete this this group from the database? All students will be permanently deleted", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                groupRep.DeleteGroup(comboBoxGroupDeleteGroup.SelectedItem.ToString(), Convert.ToInt32(comboBoxYearDeleteGroup.SelectedItem.ToString()));
                MessageBox.Show("The group has been successfully deleted.");
            }
        }

        private void comboBoxYearDeleteGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroupDeleteGroup, comboBoxYearDeleteGroup);
        }

        private void buttonDeleteTopic_Click(object sender, EventArgs e)
        {
            SqlTopicRepository topicRep = new SqlTopicRepository(Program.ConnectionString);
            if (MessageBox.Show("Are you sure you want delete this this topic from the database? All questions will be permanently deleted", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                topicRep.DeleteTopic(comboBoxTopicDeleteTopic.SelectedItem.ToString());
                MessageBox.Show("The topic has been successfully deleted.");
            }
        }
    }
}
