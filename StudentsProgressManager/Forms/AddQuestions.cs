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

namespace StudentsProgressManager
{
    public partial class AddQuestions : Form
    {
        public AddQuestions()
        {
            InitializeComponent();
            Program.ShowTopicsToCombobox(comboBoxTopic);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxAnswer.Text != "" && textBoxQuestion.Text != "")
            {
                SqlAnswerRepository answerRep = new SqlAnswerRepository(Program.ConnectionString);
                if (MessageBox.Show("Are you sure you want add this question to the database?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    answerRep.AddQuestion(textBoxQuestion.Text, textBoxAnswer.Text, comboBoxTopic.SelectedItem.ToString());
                    MessageBox.Show("A new question has been successfully added to the database!");
                }

            }
        }
    }
}
