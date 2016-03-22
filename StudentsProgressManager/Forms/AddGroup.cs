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
    public partial class AddGroup : Form
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlGroupRepository groupRep = new SqlGroupRepository(Program.ConnectionString);
            if (textBoxGroup.Text != "")
            {
                string groupName = textBoxGroup.Text;
                int year = (int)numericUpDownYear.Value;
                groupRep.AddGroup(groupName, year);
                MessageBox.Show("New group has been successfully added!");
                DialogResult = DialogResult.OK;
            }
        }
    }
}