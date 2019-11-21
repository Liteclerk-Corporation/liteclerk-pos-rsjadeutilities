using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSJadeUtilities.Forms.Account
{
    public partial class SysAccountForm : Form
    {
        public SysAccountForm()
        {
            InitializeComponent();
        }

        public Data.posDataContext db = new Data.posDataContext();

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        public void login()
        {
            try
            {
                String username = textBoxUsername.Text;
                String password = textBoxPassword.Text;

                var user = from d in db.MstUsers
                           where d.UserName == username
                           && d.Password == password
                           select d;

                if (user.Any())
                {
                    Hide();

                    Software.MenuForm menuForm = new Software.MenuForm();
                    menuForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void credentials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
