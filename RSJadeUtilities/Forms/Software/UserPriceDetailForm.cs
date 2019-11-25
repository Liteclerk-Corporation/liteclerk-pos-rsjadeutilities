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
    public partial class UserPriceDetailForm : Form
    {
        public UserPriceForm userPriceForm;
        public Int32 userPriceUserId;

        public UserPriceDetailForm(UserPriceForm form, Int32 userId)
        {
            InitializeComponent();

            userPriceForm = form;
            userPriceUserId = userId;

            GetItemPriceDescriptions();
        }

        public Data.posDataContext db = new Data.posDataContext();

        public void GetItemPriceDescriptions()
        {
            var itemDescirptions = from d in db.MstItemPrices
                                   group d by d.PriceDescription
                                   into g
                                   select g.Key;

            if (itemDescirptions.Any())
            {
                comboBoxPriceDescription.DataSource = itemDescirptions.ToList();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Data.MstUserPrice newUserPrice = new Data.MstUserPrice()
                {
                    UserId = userPriceUserId,
                    PriceDescription = comboBoxPriceDescription.Text
                };

                db.MstUserPrices.InsertOnSubmit(newUserPrice);
                db.SubmitChanges();

                userPriceForm.UpdateUserPriceDataSource();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
