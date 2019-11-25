using PagedList;
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

            GetUsers();
        }

        public Data.posDataContext db = new Data.posDataContext();

        private static List<DataGridViewModels.DgvUserPriceListModel> userPriceListData = new List<DataGridViewModels.DgvUserPriceListModel>();
        private static Int32 pageNumber = 1, pageSize = 50;
        private PagedList<DataGridViewModels.DgvUserPriceListModel> userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, pageNumber, pageSize);

        private void UserPriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Int32 userId = Convert.ToInt32(comboBoxUsers.SelectedValue);

            UserPriceDetailForm userPriceDetailForm = new UserPriceDetailForm(this, userId);
            userPriceDetailForm.ShowDialog();
        }

        public void GetUsers()
        {
            var users = from d in db.MstUsers
                        where d.IsLocked == true
                        select new
                        {
                            d.Id,
                            d.FullName
                        };

            if (users.Any())
            {
                comboBoxUsers.DataSource = users;
                comboBoxUsers.ValueMember = "Id";
                comboBoxUsers.DisplayMember = "FullName";

                CreateUserPriceDataGridView();
            }
            else
            {
                DialogResult emptyUsers = MessageBox.Show("Empty Users", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (emptyUsers == DialogResult.OK)
                {
                    Close();

                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                }
            }
        }

        public void UpdateUserPriceDataSource()
        {
            Int32 userId = Convert.ToInt32(comboBoxUsers.SelectedValue);

            SetUserPriceDataSourceAsync(userId);
        }

        public async void SetUserPriceDataSourceAsync(Int32 userId)
        {
            List<DataGridViewModels.DgvUserPriceListModel> getUserPriceData = await GetUserPriceDataTask(userId);
            if (getUserPriceData.Any())
            {
                userPriceListData = getUserPriceData;
                userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, pageNumber, pageSize);

                if (userPriceListPageList.PageCount == 1)
                {
                    buttonUserPricePageListFirst.Enabled = false;
                    buttonUserPricePageListPrevious.Enabled = false;
                    buttonUserPricePageListNext.Enabled = false;
                    buttonUserPricePageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonUserPricePageListFirst.Enabled = false;
                    buttonUserPricePageListPrevious.Enabled = false;
                    buttonUserPricePageListNext.Enabled = true;
                    buttonUserPricePageListLast.Enabled = true;
                }
                else if (pageNumber == userPriceListPageList.PageCount)
                {
                    buttonUserPricePageListFirst.Enabled = true;
                    buttonUserPricePageListPrevious.Enabled = true;
                    buttonUserPricePageListNext.Enabled = false;
                    buttonUserPricePageListLast.Enabled = false;
                }
                else
                {
                    buttonUserPricePageListFirst.Enabled = true;
                    buttonUserPricePageListPrevious.Enabled = true;
                    buttonUserPricePageListNext.Enabled = true;
                    buttonUserPricePageListLast.Enabled = true;
                }

                textBoxUserPricePageNumber.Text = pageNumber + " / " + userPriceListPageList.PageCount;
                bindingSourceUserPrice.DataSource = userPriceListPageList;
            }
            else
            {
                buttonUserPricePageListFirst.Enabled = false;
                buttonUserPricePageListPrevious.Enabled = false;
                buttonUserPricePageListNext.Enabled = false;
                buttonUserPricePageListLast.Enabled = false;

                pageNumber = 1;

                userPriceListData = new List<DataGridViewModels.DgvUserPriceListModel>();
                bindingSourceUserPrice.Clear();
                textBoxUserPricePageNumber.Text = "1 / 1";
            }
        }

        private List<Models.MstUserPriceModel> GetUserPriceList(Int32 userId)
        {
            var userPrices = from d in db.MstUserPrices
                             where d.UserId == userId
                             select new Models.MstUserPriceModel
                             {
                                 Id = d.Id,
                                 PriceDescription = d.PriceDescription
                             };

            return userPrices.ToList();
        }

        private Task<List<DataGridViewModels.DgvUserPriceListModel>> GetUserPriceDataTask(Int32 userId)
        {
            List<Models.MstUserPriceModel> listUserPrice = GetUserPriceList(userId);
            if (listUserPrice.Any())
            {
                var items = from d in listUserPrice
                            select new DataGridViewModels.DgvUserPriceListModel
                            {
                                UserPriceButtonDelete = "Delete",
                                UserPriceListId = d.Id,
                                UserPriceListPriceDescription = d.PriceDescription
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<DataGridViewModels.DgvUserPriceListModel>());
            }
        }

        public void CreateUserPriceDataGridView()
        {
            UpdateUserPriceDataSource();

            dataGridViewUserPrice.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUserPrice.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUserPrice.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUserPrice.DataSource = bindingSourceUserPrice;
        }

        public void GetUserPriceCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewUserPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && dataGridViewUserPrice.CurrentCell.ColumnIndex == dataGridViewUserPrice.Columns["UserPriceButtonDelete"].Index)
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Price?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Int32 userPriceId = Convert.ToInt32(dataGridViewUserPrice.Rows[e.RowIndex].Cells[dataGridViewUserPrice.Columns["UserPriceListId"].Index].Value);

                        var userPrice = from d in db.MstUserPrices
                                        where d.Id == userPriceId
                                        select d;

                        if (userPrice.Any())
                        {
                            var deletePrice = userPrice.FirstOrDefault();

                            db.MstUserPrices.DeleteOnSubmit(deletePrice);
                            db.SubmitChanges();

                            UpdateUserPriceDataSource();
                        }
                        else
                        {
                            MessageBox.Show("User price not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUserPriceDataSource();
        }

        private void buttonUserPricePageListFirst_Click(object sender, EventArgs e)
        {
            userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, 1, pageSize);
            bindingSourceUserPrice.DataSource = userPriceListPageList;

            buttonUserPricePageListFirst.Enabled = false;
            buttonUserPricePageListPrevious.Enabled = false;
            buttonUserPricePageListNext.Enabled = true;
            buttonUserPricePageListLast.Enabled = true;

            pageNumber = 1;
            textBoxUserPricePageNumber.Text = pageNumber + " / " + userPriceListPageList.PageCount;
        }

        private void buttonUserPricePageListPrevious_Click(object sender, EventArgs e)
        {
            if (userPriceListPageList.HasPreviousPage == true)
            {
                userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, --pageNumber, pageSize);
                bindingSourceUserPrice.DataSource = userPriceListPageList;
            }

            buttonUserPricePageListNext.Enabled = true;
            buttonUserPricePageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonUserPricePageListFirst.Enabled = false;
                buttonUserPricePageListPrevious.Enabled = false;
            }

            textBoxUserPricePageNumber.Text = pageNumber + " / " + userPriceListPageList.PageCount;
        }

        private void buttonUserPricePageListNext_Click(object sender, EventArgs e)
        {
            if (userPriceListPageList.HasNextPage == true)
            {
                userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, ++pageNumber, pageSize);
                bindingSourceUserPrice.DataSource = userPriceListPageList;
            }

            buttonUserPricePageListFirst.Enabled = true;
            buttonUserPricePageListPrevious.Enabled = true;

            if (pageNumber == userPriceListPageList.PageCount)
            {
                buttonUserPricePageListNext.Enabled = false;
                buttonUserPricePageListLast.Enabled = false;
            }

            textBoxUserPricePageNumber.Text = pageNumber + " / " + userPriceListPageList.PageCount;
        }

        private void buttonUserPricePageListLast_Click(object sender, EventArgs e)
        {
            userPriceListPageList = new PagedList<DataGridViewModels.DgvUserPriceListModel>(userPriceListData, userPriceListPageList.PageCount, pageSize);
            bindingSourceUserPrice.DataSource = userPriceListPageList;

            buttonUserPricePageListFirst.Enabled = true;
            buttonUserPricePageListPrevious.Enabled = true;
            buttonUserPricePageListNext.Enabled = false;
            buttonUserPricePageListLast.Enabled = false;

            pageNumber = userPriceListPageList.PageCount;
            textBoxUserPricePageNumber.Text = pageNumber + " / " + userPriceListPageList.PageCount;
        }

    }
}
