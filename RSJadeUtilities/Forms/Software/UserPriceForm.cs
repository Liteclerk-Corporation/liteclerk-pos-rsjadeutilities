using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSJadeUtilities.Forms.Software
{
    public partial class UserPriceForm : Form
    {
        public UserPriceForm()
        {
            InitializeComponent();
        }

        private void UserPriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserPriceDetailForm userPriceDetailForm = new UserPriceDetailForm();
            userPriceDetailForm.ShowDialog();
        }
    }
}
