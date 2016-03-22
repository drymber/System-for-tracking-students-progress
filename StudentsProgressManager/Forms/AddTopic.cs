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
    public partial class AddTopic : Form
    {
        public AddTopic()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "")
            {
                SqlTopicRepository topicRep = new SqlTopicRepository(Program.ConnectionString);
                if (MessageBox.Show("Are you sure you want add this topic to the database?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    topicRep.AddTopic(textBoxTitle.Text);
                    MessageBox.Show("A new topic has been successfully added to the database!");
                }
            }
        }
    }
}
