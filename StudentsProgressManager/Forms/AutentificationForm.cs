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
using StudentsProgressManager.Code;

namespace StudentsProgressManager
{
    public partial class AutentificationForm : Form
    {
        public AutentificationForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = Encryptor.MD5Hash(textBoxLogin.Text);
            string password = Encryptor.MD5Hash(textBoxPassword.Text);
            SqlUserRepository userRep = new SqlUserRepository(Program.ConnectionString);
            User user = userRep.GetUserByLogin(login, password);
            if (user == null)
            {
                MessageBox.Show(this, "Invalid user name or password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentUser.Initialize(user);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
