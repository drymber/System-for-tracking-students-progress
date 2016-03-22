using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using StudentsProgress.Repositories;
using StudentsProgressEntities;
using System.Configuration;

namespace StudentsProgressManager
{
    
    static class Program
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["StudentsProgressConnectionString"].ConnectionString;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            AutentificationForm autentificationForm = new AutentificationForm();
            if (autentificationForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }

        #region Methods
        public static void ShowGroupsToComboBox(ComboBox comboGroup, ComboBox comboYear)
        {
            comboGroup.Items.Clear();
            string year = comboYear.SelectedItem.ToString();
            SqlGroupRepository groupRepository = new SqlGroupRepository(ConnectionString);
            List<Group> groups = groupRepository.GetGroup(year);
            foreach (Group g in groups)
            {
                comboGroup.Items.Add(g.Name);
            }
            if (groups.Count > 0)
            {
                comboGroup.SelectedItem = comboGroup.Items[0];
            }

        }
        public static void ShowYearsToCombo(ComboBox comboBox)
        {
            SqlGroupRepository sqlGroupRepository = new SqlGroupRepository(ConnectionString);
            List<int> years = sqlGroupRepository.GetAcademicYears();
            foreach (int year in years)
            {
                comboBox.Items.Add(year);
            }
            if (years.Count > 0)
            {
                comboBox.SelectedItem = comboBox.Items[0];
            }
        }
        public static void ShowStudentsToCombo(string firstName, string lastName, string group, int year, ComboBox comboStudent)
        {
            comboStudent.Items.Clear();
            SqlStudentRepository st = new SqlStudentRepository(ConnectionString);
            List<Student> students = st.GetStudent(firstName, lastName, group, year);

            foreach (Student student in students)
            {
                comboStudent.Items.Add(student.FirstName + " " + student.LastName);
            }
            if (students.Count > 0)
            {
                comboStudent.SelectedItem = comboStudent.Items[0];
            }
        }
        public static void ShowTopicsToCombobox(ComboBox comboTopic)
        {
            comboTopic.Items.Clear();
            SqlTopicRepository topicRepository = new SqlTopicRepository(ConnectionString);
            List<Topic> topics = topicRepository.GetTopic();
            foreach (Topic t in topics)
            {
                comboTopic.Items.Add(t.Title);
            }
            comboTopic.SelectedItem = comboTopic.Items[0];
        }
        public static Student GetStudentFromComboBox(ComboBox comboStudent, ComboBox comboYear, ComboBox comboGroup)
        {
            string groupName = comboGroup.SelectedItem.ToString();
            int year = Convert.ToInt32(comboYear.SelectedItem);
            string[] student = comboStudent.SelectedItem.ToString().Split(' ');
            SqlStudentRepository st = new SqlStudentRepository(ConnectionString);
            List<Student> students = st.GetStudent(student[0], student[1], groupName, year);
            return students[0];
        }
        #endregion

        #region Events
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
