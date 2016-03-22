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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            Program.ShowYearsToCombo(comboBoxYear);
            Program.ShowGroupsToComboBox(comboBoxGroup, comboBoxYear);
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text != "" && textBoxLastName.Text != "" && textBoxPhoneNumber.Text != "" && textBoxEmail.Text != "")
            {
                string firstName = textBoxFirstName.Text;
                string lastName = textBoxLastName.Text;
                string phoneNumber = textBoxPhoneNumber.Text;
                string email = textBoxEmail.Text;
                int age = (int)numericUpDownAge.Value;
                string group = comboBoxGroup.SelectedItem.ToString();
                string year = comboBoxYear.SelectedItem.ToString();

                SqlStudentRepository studentRep = new SqlStudentRepository(ConfigurationManager.ConnectionStrings["StudentsProgressConnectionString"].ConnectionString);
                int studentId = studentRep.AddStudent(firstName, lastName, group, year, phoneNumber, email, age);
                string message = String.Format("The student was successfully added to the database! Student's Id = {0}", studentId.ToString());
                MessageBox.Show(message, "Information");
            }
        }
        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ShowGroupsToComboBox(comboBoxGroup, comboBoxYear);
        }
    }
}
