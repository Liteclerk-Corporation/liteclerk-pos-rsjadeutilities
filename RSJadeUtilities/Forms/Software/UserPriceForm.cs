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
            UserPriceDetailForm userPriceDetailForm = new UserPriceDetailForm();
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

            }
        }

        public void UpdateUserPriceDataSource()
        {
            SetUserPriceDataSourceAsync();
        }

        public async void SetUserPriceDataSourceAsync()
        {
            List<DataGridViewModels.DgvUserPriceListModel> getUserPriceData = await GetUserPriceDataTask();
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

        private List<Models.MstUserPriceModel> GetUserPriceList()
        {
            var userPrices = from d in db.MstUserPrices
                             where d.UserId == Convert.ToInt32(comboBoxUsers.SelectedValue)
                             select new Models.MstUserPriceModel
                             {
                                 Id = d.Id,
                                 UserId = d.UserId,
                                 FullName = d.MstUser.FullName,
                                 PriceDescription = d.PriceDescription
                             };

            return userPrices.ToList();
        }

        private Task<List<DataGridViewModels.DgvUserPriceListModel>> GetUserPriceDataTask()
        {
            List<Models.MstUserPriceModel> listUserPrice = GetUserPriceList();
            if (listUserPrice.Any())
            {
                var items = from d in listUserPrice
                            select new DataGridViewModels.DgvUserPriceListModel
                            {
                                UserPriceButtonEdit = "Edit",
                                UserPriceButtonDelete = "Delete",
                                UserPriceListId = d.Id,
                                UserPriceListUserId = d.UserId,
                                UserPriceListUserFullName = d.FullName,
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

            //dataGridViewUserPrice.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            //dataGridViewUserPrice.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            //dataGridViewUserPrice.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            //dataGridViewUserPrice.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            //dataGridViewUserPrice.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            //dataGridViewUserPrice.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUserPrice.DataSource = bindingSourceUserPrice;
        }

        public void GetUserPriceCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUserPriceDataSource();
        }
    }
}
