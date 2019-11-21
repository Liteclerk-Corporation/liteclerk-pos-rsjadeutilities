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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonUserPrice_Click(object sender, EventArgs e)
        {
            Hide();

            UserPriceForm userPriceForm = new UserPriceForm();
            userPriceForm.Show();
        }

        private void buttonInventoryReport_Click(object sender, EventArgs e)
        {
            Hide();

            InventoryReportForm inventoryReportForm = new InventoryReportForm();
            inventoryReportForm.Show();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Account.SysAccountForm accountForm = new Account.SysAccountForm();
            accountForm.Show();
        }
    }
}
