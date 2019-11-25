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
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();

            GetSuppliers();
        }

        public Data.posDataContext db = new Data.posDataContext();

        private static List<DataGridViewModels.DgvInventoryReportListModel> inventoryReportListData = new List<DataGridViewModels.DgvInventoryReportListModel>();
        private static Int32 pageNumber = 1, pageSize = 50;
        private PagedList<DataGridViewModels.DgvInventoryReportListModel> inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, pageNumber, pageSize);

        private void InventoryReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        public void GetSuppliers()
        {
            var suppliers = from d in db.MstSuppliers
                            select d;

            if (suppliers.Any())
            {
                comboBoxSupplier.DataSource = suppliers;
                comboBoxSupplier.ValueMember = "Id";
                comboBoxSupplier.DisplayMember = "Supplier";
            }
            else
            {
                DialogResult emptyUsers = MessageBox.Show("Empty Suppliers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (emptyUsers == DialogResult.OK)
                {
                    Close();

                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                }
            }

            CreateInventoryReportDataGridView();
        }


        public void UpdateInventoryReportDataSource()
        {
            Int32 supplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue);
            DateTime dateStart = dateTimePickerDateStart.Value;
            DateTime dateEnd = dateTimePickerDateEnd.Value;

            SetInventoryReportDataSourceAsync(supplierId, dateStart, dateEnd);
        }

        public async void SetInventoryReportDataSourceAsync(Int32 supplierId, DateTime dateStart, DateTime dateEnd)
        {
            List<DataGridViewModels.DgvInventoryReportListModel> getInventoryReportData = await GetInventoryReportDataTask(supplierId, dateStart, dateEnd);
            if (getInventoryReportData.Any())
            {
                inventoryReportListData = getInventoryReportData;
                inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, pageNumber, pageSize);

                if (inventoryReportListPageList.PageCount == 1)
                {
                    buttonInventoryReportPageListFirst.Enabled = false;
                    buttonInventoryReportPageListPrevious.Enabled = false;
                    buttonInventoryReportPageListNext.Enabled = false;
                    buttonInventoryReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonInventoryReportPageListFirst.Enabled = false;
                    buttonInventoryReportPageListPrevious.Enabled = false;
                    buttonInventoryReportPageListNext.Enabled = true;
                    buttonInventoryReportPageListLast.Enabled = true;
                }
                else if (pageNumber == inventoryReportListPageList.PageCount)
                {
                    buttonInventoryReportPageListFirst.Enabled = true;
                    buttonInventoryReportPageListPrevious.Enabled = true;
                    buttonInventoryReportPageListNext.Enabled = false;
                    buttonInventoryReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonInventoryReportPageListFirst.Enabled = true;
                    buttonInventoryReportPageListPrevious.Enabled = true;
                    buttonInventoryReportPageListNext.Enabled = true;
                    buttonInventoryReportPageListLast.Enabled = true;
                }

                textBoxInventoryReportPageNumber.Text = pageNumber + " / " + inventoryReportListPageList.PageCount;
                bindingSourceInventoryReport.DataSource = inventoryReportListPageList;
            }
            else
            {
                buttonInventoryReportPageListFirst.Enabled = false;
                buttonInventoryReportPageListPrevious.Enabled = false;
                buttonInventoryReportPageListNext.Enabled = false;
                buttonInventoryReportPageListLast.Enabled = false;

                pageNumber = 1;

                inventoryReportListData = new List<DataGridViewModels.DgvInventoryReportListModel>();
                bindingSourceInventoryReport.Clear();
                textBoxInventoryReportPageNumber.Text = "1 / 1";
            }
        }

        private List<Models.MstInventoryReportModel> GetInventoryReportList(Int32 supplierId, DateTime dateStart, DateTime dateEnd)
        {
            List<Models.MstInventoryReportModel> newRepInventoryReportEntity = new List<Models.MstInventoryReportModel>();

            var inQuantityInventories = from d in db.TrnStockInLines
                                        where d.TrnStockIn.IsLocked == true
                                        && d.TrnStockIn.IsReturn == false
                                        && d.MstItem.DefaultSupplierId == supplierId
                                        select new Models.MstInventoryReportModel
                                        {
                                            Id = d.Id,
                                            InventoryDate = d.TrnStockIn.StockInDate,
                                            Barcode = d.MstItem.BarCode,
                                            ItemDescription = d.MstItem.ItemDescription,
                                            BeginningQuantity = 0,
                                            InQuantity = d.Quantity,
                                            ReturnQuantity = 0,
                                            SoldQuantity = 0,
                                            OutQuantity = 0,
                                            EndingQuantity = 0,
                                            Unit = d.MstUnit.Unit,
                                            Cost = d.MstItem.Cost,
                                            Amount = 0
                                        };

            if (inQuantityInventories.Any())
            {
                newRepInventoryReportEntity.AddRange(inQuantityInventories.ToList());
            }

            var returnQuantityInventories = from d in db.TrnStockInLines
                                            where d.TrnStockIn.IsLocked == true
                                            && d.TrnStockIn.IsReturn == true
                                            && d.MstItem.DefaultSupplierId == supplierId
                                            select new Models.MstInventoryReportModel
                                            {
                                                Id = d.Id,
                                                InventoryDate = d.TrnStockIn.StockInDate,
                                                Barcode = d.MstItem.BarCode,
                                                ItemDescription = d.MstItem.ItemDescription,
                                                BeginningQuantity = 0,
                                                InQuantity = 0,
                                                ReturnQuantity = d.Quantity,
                                                SoldQuantity = 0,
                                                OutQuantity = 0,
                                                EndingQuantity = 0,
                                                Unit = d.MstUnit.Unit,
                                                Cost = d.MstItem.Cost,
                                                Amount = 0
                                            };

            if (returnQuantityInventories.Any())
            {
                newRepInventoryReportEntity.AddRange(returnQuantityInventories.ToList());
            }

            var soldQuantityInventories = from d in db.TrnSalesLines
                                          where d.TrnSale.IsLocked == true
                                          && d.TrnSale.IsCancelled == false
                                          && d.MstItem.DefaultSupplierId == supplierId
                                          select new Models.MstInventoryReportModel
                                          {
                                              Id = d.Id,
                                              InventoryDate = d.TrnSale.SalesDate,
                                              Barcode = d.MstItem.BarCode,
                                              ItemDescription = d.MstItem.ItemDescription,
                                              BeginningQuantity = 0,
                                              InQuantity = 0,
                                              ReturnQuantity = 0,
                                              SoldQuantity = d.Quantity,
                                              OutQuantity = 0,
                                              EndingQuantity = 0,
                                              Unit = d.MstUnit.Unit,
                                              Cost = d.MstItem.Cost,
                                              Amount = 0
                                          };

            if (soldQuantityInventories.Any())
            {
                newRepInventoryReportEntity.AddRange(soldQuantityInventories.ToList());
            }

            var outQuantityInventories = from d in db.TrnStockOutLines
                                         where d.TrnStockOut.IsLocked == true
                                         && d.MstItem.DefaultSupplierId == supplierId
                                         select new Models.MstInventoryReportModel
                                         {
                                             Id = d.Id,
                                             InventoryDate = d.TrnStockOut.StockOutDate,
                                             Barcode = d.MstItem.BarCode,
                                             ItemDescription = d.MstItem.ItemDescription,
                                             BeginningQuantity = 0,
                                             InQuantity = 0,
                                             ReturnQuantity = 0,
                                             SoldQuantity = 0,
                                             OutQuantity = d.Quantity,
                                             EndingQuantity = 0,
                                             Unit = d.MstUnit.Unit,
                                             Cost = d.MstItem.Cost,
                                             Amount = 0
                                         };

            if (outQuantityInventories.Any())
            {
                newRepInventoryReportEntity.AddRange(outQuantityInventories.ToList());
            }

            if (newRepInventoryReportEntity.Any())
            {
                var begInventories = from d in newRepInventoryReportEntity
                                     where d.InventoryDate < dateStart
                                     select new Models.MstInventoryReportModel
                                     {
                                         Document = "Beg",
                                         Id = d.Id,
                                         InventoryDate = d.InventoryDate,
                                         Barcode = d.Barcode,
                                         ItemDescription = d.ItemDescription,
                                         BeginningQuantity = 0,
                                         InQuantity = d.InQuantity,
                                         ReturnQuantity = d.ReturnQuantity,
                                         SoldQuantity = d.SoldQuantity,
                                         OutQuantity = d.OutQuantity,
                                         EndingQuantity = 0,
                                         Unit = d.Unit,
                                         Cost = d.Cost,
                                         Amount = 0
                                     };

                var curInventories = from d in newRepInventoryReportEntity
                                     where d.InventoryDate >= dateStart
                                     && d.InventoryDate <= dateEnd
                                     select new Models.MstInventoryReportModel
                                     {
                                         Document = "Cur",
                                         Id = d.Id,
                                         InventoryDate = d.InventoryDate,
                                         Barcode = d.Barcode,
                                         ItemDescription = d.ItemDescription,
                                         BeginningQuantity = 0,
                                         InQuantity = d.InQuantity,
                                         ReturnQuantity = d.ReturnQuantity,
                                         SoldQuantity = d.SoldQuantity,
                                         OutQuantity = d.OutQuantity,
                                         EndingQuantity = 0,
                                         Unit = d.Unit,
                                         Cost = d.Cost,
                                         Amount = 0
                                     };

                var unionInventories = begInventories.Union(curInventories);

                if (unionInventories.ToList().Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.Barcode,
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Models.MstInventoryReportModel
                                      {
                                          Barcode = g.Key.Barcode,
                                          ItemDescription = g.Key.ItemDescription,
                                          BeginningQuantity = g.Sum(s => s.Document == "Beg" ? (s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity : 0),
                                          InQuantity = g.Sum(s => s.Document == "Cur" ? s.InQuantity : 0),
                                          ReturnQuantity = g.Sum(s => s.Document == "Cur" ? s.ReturnQuantity : 0),
                                          SoldQuantity = g.Sum(s => s.Document == "Cur" ? s.SoldQuantity : 0),
                                          OutQuantity = g.Sum(s => s.Document == "Cur" ? s.OutQuantity : 0),
                                          EndingQuantity = g.Sum(s => s.Document == "Beg" ? (s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity : 0) +
                                                           g.Sum(s => s.Document == "Cur" ? s.InQuantity : 0) +
                                                           g.Sum(s => s.Document == "Cur" ? s.ReturnQuantity : 0) - 
                                                           g.Sum(s => s.Document == "Cur" ? s.SoldQuantity : 0) -
                                                           g.Sum(s => s.Document == "Cur" ? s.OutQuantity : 0),
                                          Unit = g.Key.Unit,
                                          Cost = g.Key.Cost,
                                          Amount = g.Key.Cost * (
                                                        g.Sum(s => s.Document == "Beg" ? (s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity : 0) +
                                                        g.Sum(s => s.Document == "Cur" ? s.InQuantity : 0) +
                                                        g.Sum(s => s.Document == "Cur" ? s.ReturnQuantity : 0) -
                                                        g.Sum(s => s.Document == "Cur" ? s.SoldQuantity : 0) -
                                                        g.Sum(s => s.Document == "Cur" ? s.OutQuantity : 0)
                                                   )
                                      };

                    buttonGet.Text = "Get";
                    buttonGet.Enabled = true;

                    return inventories.OrderBy(d => d.ItemDescription).ToList();
                }
                else
                {
                    buttonGet.Text = "Get";
                    buttonGet.Enabled = true;

                    return new List<Models.MstInventoryReportModel>();
                }
            }
            else
            {
                buttonGet.Text = "Get";
                buttonGet.Enabled = true;

                return new List<Models.MstInventoryReportModel>();
            }
        }

        private Task<List<DataGridViewModels.DgvInventoryReportListModel>> GetInventoryReportDataTask(Int32 supplierId, DateTime dateStart, DateTime dateEnd)
        {
            List<Models.MstInventoryReportModel> listInventoryReport = GetInventoryReportList(supplierId, dateStart, dateEnd);
            if (listInventoryReport.Any())
            {
                var items = from d in listInventoryReport
                            select new DataGridViewModels.DgvInventoryReportListModel
                            {
                                InventoryReportListId = d.Id,
                                InventoryReportListBarcode = d.Barcode,
                                InventoryReportListItemDescription = d.ItemDescription,
                                InventoryReportListBeginningQuantity = d.BeginningQuantity.ToString("#,##0.00"),
                                InventoryReportListInQuantity = d.InQuantity.ToString("#,##0.00"),
                                InventoryReportListReturnQuantity = d.ReturnQuantity.ToString("#,##0.00"),
                                InventoryReportListSoldQuantity = d.SoldQuantity.ToString("#,##0.00"),
                                InventoryReportListOutQuantity = d.OutQuantity.ToString("#,##0.00"),
                                InventoryReportListEndingQuantity = d.EndingQuantity.ToString("#,##0.00"),
                                InventoryReportListUnit = d.Unit,
                                InventoryReportListCost = d.Cost.ToString("#,##0.00"),
                                InventoryReportListAmount = d.Amount.ToString("#,##0.00")
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<DataGridViewModels.DgvInventoryReportListModel>());
            }
        }

        public void CreateInventoryReportDataGridView()
        {
            UpdateInventoryReportDataSource();
            dataGridViewInventoryReport.DataSource = bindingSourceInventoryReport;
        }

        public void GetInventoryReportCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewInventoryReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInventoryReportDataSource();
        }

        private void buttonInventoryReportPageListFirst_Click(object sender, EventArgs e)
        {
            inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, 1, pageSize);
            bindingSourceInventoryReport.DataSource = inventoryReportListPageList;

            buttonInventoryReportPageListFirst.Enabled = false;
            buttonInventoryReportPageListPrevious.Enabled = false;
            buttonInventoryReportPageListNext.Enabled = true;
            buttonInventoryReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + inventoryReportListPageList.PageCount;
        }

        private void buttonInventoryReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (inventoryReportListPageList.HasPreviousPage == true)
            {
                inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, --pageNumber, pageSize);
                bindingSourceInventoryReport.DataSource = inventoryReportListPageList;
            }

            buttonInventoryReportPageListNext.Enabled = true;
            buttonInventoryReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonInventoryReportPageListFirst.Enabled = false;
                buttonInventoryReportPageListPrevious.Enabled = false;
            }

            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + inventoryReportListPageList.PageCount;
        }

        private void buttonInventoryReportPageListNext_Click(object sender, EventArgs e)
        {
            if (inventoryReportListPageList.HasNextPage == true)
            {
                inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, ++pageNumber, pageSize);
                bindingSourceInventoryReport.DataSource = inventoryReportListPageList;
            }

            buttonInventoryReportPageListFirst.Enabled = true;
            buttonInventoryReportPageListPrevious.Enabled = true;

            if (pageNumber == inventoryReportListPageList.PageCount)
            {
                buttonInventoryReportPageListNext.Enabled = false;
                buttonInventoryReportPageListLast.Enabled = false;
            }

            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + inventoryReportListPageList.PageCount;
        }

        private void buttonInventoryReportPageListLast_Click(object sender, EventArgs e)
        {
            inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, inventoryReportListPageList.PageCount, pageSize);
            bindingSourceInventoryReport.DataSource = inventoryReportListPageList;

            buttonInventoryReportPageListFirst.Enabled = true;
            buttonInventoryReportPageListPrevious.Enabled = true;
            buttonInventoryReportPageListNext.Enabled = false;
            buttonInventoryReportPageListLast.Enabled = false;

            pageNumber = inventoryReportListPageList.PageCount;
            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + inventoryReportListPageList.PageCount;
        }

        private void dateTimePickerDateStart_ValueChanged(object sender, EventArgs e)
        {
            //UpdateInventoryReportDataSource();
        }

        private void dateTimePickerDateEnd_ValueChanged(object sender, EventArgs e)
        {
            //UpdateInventoryReportDataSource();
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UpdateInventoryReportDataSource();
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            buttonGet.Text = "Loading...";
            buttonGet.Enabled = false;

            UpdateInventoryReportDataSource();
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {

        }
    }
}