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
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();
        }

        private void InventoryReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }
    }
}
