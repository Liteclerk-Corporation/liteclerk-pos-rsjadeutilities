using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public Data.posDataContext db = new Data.posDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        private static List<DataGridViewModels.DgvInventoryReportListModel> inventoryReportListData = new List<DataGridViewModels.DgvInventoryReportListModel>();
        private static Int32 pageNumber = 1, pageSize = 50;
        private PagedList<DataGridViewModels.DgvInventoryReportListModel> inventoryReportListPageList = new PagedList<DataGridViewModels.DgvInventoryReportListModel>(inventoryReportListData, pageNumber, pageSize);

        public Boolean isInventoryFetched = false;

        private void InventoryReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        public void GetSuppliers()
        {
            List<Entities.MstSupplierEntity> supplierEntity = new List<Entities.MstSupplierEntity>();
            supplierEntity.Add(new Entities.MstSupplierEntity()
            {
                Id = 0,
                Supplier = "All Suppliers"
            });

            var suppliers = from d in db.MstSuppliers
                            select new Entities.MstSupplierEntity
                            {
                                Id = d.Id,
                                Supplier = d.Supplier
                            };



            if (suppliers.Any())
            {
                supplierEntity.AddRange(suppliers.ToList());

                comboBoxSupplier.DataSource = supplierEntity;
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
            if (supplierId == 0)
            {
                var beginningInInventories = from d in db.TrnStockInLines
                                             where d.TrnStockIn.IsLocked == true
                                             && d.TrnStockIn.StockInDate < dateStart.Date
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Beg",
                                                 Id = "Beg-In-" + d.Id,
                                                 InventoryDate = d.TrnStockIn.StockInDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 Barcode = d.MstItem.BarCode,
                                                 ItemDescription = d.MstItem.ItemDescription,
                                                 BeginningQuantity = d.Quantity,
                                                 InQuantity = 0,
                                                 ReturnQuantity = 0,
                                                 SoldQuantity = 0,
                                                 OutQuantity = 0,
                                                 EndingQuantity = 0,
                                                 Unit = d.MstUnit.Unit,
                                                 Cost = d.MstItem.Cost,
                                                 Amount = 0
                                             };

                var beginningSoldInventories = from d in db.TrnSalesLines
                                               where d.TrnSale.IsLocked == true
                                               && d.TrnSale.IsCancelled == false
                                               && d.TrnSale.SalesDate < dateStart.Date
                                               select new Models.MstInventoryReportModel
                                               {
                                                   Document = "Beg",
                                                   Id = "Beg-Sold-" + d.Id,
                                                   InventoryDate = d.TrnSale.SalesDate,
                                                   Supplier = d.MstItem.MstSupplier.Supplier,
                                                   Barcode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = d.Quantity * -1,
                                                   InQuantity = 0,
                                                   ReturnQuantity = 0,
                                                   SoldQuantity = 0,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Amount = 0
                                               };

                var beginningOutInventories = from d in db.TrnStockOutLines
                                              where d.TrnStockOut.IsLocked == true
                                              && d.TrnStockOut.StockOutDate < dateStart.Date
                                              select new Models.MstInventoryReportModel
                                              {
                                                  Document = "Beg",
                                                  Id = "Beg-Out-" + d.Id,
                                                  InventoryDate = d.TrnStockOut.StockOutDate,
                                                  Supplier = d.MstItem.MstSupplier.Supplier,
                                                  Barcode = d.MstItem.BarCode,
                                                  ItemDescription = d.MstItem.ItemDescription,
                                                  BeginningQuantity = d.Quantity * -1,
                                                  InQuantity = 0,
                                                  ReturnQuantity = 0,
                                                  SoldQuantity = 0,
                                                  OutQuantity = 0,
                                                  EndingQuantity = 0,
                                                  Unit = d.MstUnit.Unit,
                                                  Cost = d.MstItem.Cost,
                                                  Amount = 0
                                              };

                var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningOutInventories.ToList());

                var currentInInventories = from d in db.TrnStockInLines
                                           where d.TrnStockIn.IsLocked == true
                                           && d.TrnStockIn.StockInDate >= dateStart.Date
                                           && d.TrnStockIn.StockInDate <= dateEnd.Date
                                           select new Models.MstInventoryReportModel
                                           {
                                               Document = "Cur",
                                               Id = "Cur-In-" + d.Id,
                                               InventoryDate = d.TrnStockIn.StockInDate,
                                               Supplier = d.MstItem.MstSupplier.Supplier,
                                               Barcode = d.MstItem.BarCode,
                                               ItemDescription = d.MstItem.ItemDescription,
                                               BeginningQuantity = 0,
                                               InQuantity = d.TrnStockIn.IsReturn == false ? d.Quantity : 0,
                                               ReturnQuantity = d.TrnStockIn.IsReturn == true ? d.Quantity : 0,
                                               SoldQuantity = 0,
                                               OutQuantity = 0,
                                               EndingQuantity = 0,
                                               Unit = d.MstUnit.Unit,
                                               Cost = d.MstItem.Cost,
                                               Amount = 0
                                           };

                var currentSoldInventories = from d in db.TrnSalesLines
                                             where d.TrnSale.IsLocked == true
                                             && d.TrnSale.IsCancelled == false
                                             && d.TrnSale.SalesDate >= dateStart.Date
                                             && d.TrnSale.SalesDate <= dateEnd.Date
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Cur",
                                                 Id = "Cur-Sold-" + d.Id,
                                                 InventoryDate = d.TrnSale.SalesDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
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

                var currentOutInventories = from d in db.TrnStockOutLines
                                            where d.TrnStockOut.IsLocked == true
                                            && d.TrnStockOut.StockOutDate >= dateStart.Date
                                            && d.TrnStockOut.StockOutDate <= dateEnd.Date
                                            select new Models.MstInventoryReportModel
                                            {
                                                Document = "Cur",
                                                Id = "Cur-Out-" + d.Id,
                                                InventoryDate = d.TrnStockOut.StockOutDate,
                                                Supplier = d.MstItem.MstSupplier.Supplier,
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

                var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentOutInventories.ToList());

                var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                if (unionInventories.Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.Supplier,
                                          d.Barcode,
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Models.MstInventoryReportModel
                                      {
                                          Supplier = g.Key.Supplier,
                                          Barcode = g.Key.Barcode,
                                          ItemDescription = g.Key.ItemDescription,
                                          BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                          InQuantity = g.Sum(s => s.InQuantity),
                                          ReturnQuantity = g.Sum(s => s.ReturnQuantity),
                                          SoldQuantity = g.Sum(s => s.SoldQuantity),
                                          OutQuantity = g.Sum(s => s.OutQuantity),
                                          EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity),
                                          Unit = g.Key.Unit,
                                          Cost = g.Key.Cost,
                                          Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity)
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
                var beginningInInventories = from d in db.TrnStockInLines
                                             where d.TrnStockIn.IsLocked == true
                                             && d.MstItem.DefaultSupplierId == supplierId
                                             && d.TrnStockIn.StockInDate < dateStart.Date
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Beg",
                                                 Id = "Beg-In-" + d.Id,
                                                 InventoryDate = d.TrnStockIn.StockInDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 Barcode = d.MstItem.BarCode,
                                                 ItemDescription = d.MstItem.ItemDescription,
                                                 BeginningQuantity = d.Quantity,
                                                 InQuantity = 0,
                                                 ReturnQuantity = 0,
                                                 SoldQuantity = 0,
                                                 OutQuantity = 0,
                                                 EndingQuantity = 0,
                                                 Unit = d.MstUnit.Unit,
                                                 Cost = d.MstItem.Cost,
                                                 Amount = 0
                                             };

                var beginningSoldInventories = from d in db.TrnSalesLines
                                               where d.TrnSale.IsLocked == true
                                               && d.TrnSale.IsCancelled == false
                                               && d.MstItem.DefaultSupplierId == supplierId
                                               && d.TrnSale.SalesDate < dateStart.Date
                                               select new Models.MstInventoryReportModel
                                               {
                                                   Document = "Beg",
                                                   Id = "Beg-Sold-" + d.Id,
                                                   InventoryDate = d.TrnSale.SalesDate,
                                                   Supplier = d.MstItem.MstSupplier.Supplier,
                                                   Barcode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = d.Quantity * -1,
                                                   InQuantity = 0,
                                                   ReturnQuantity = 0,
                                                   SoldQuantity = 0,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Amount = 0
                                               };

                var beginningOutInventories = from d in db.TrnStockOutLines
                                              where d.TrnStockOut.IsLocked == true
                                              && d.MstItem.DefaultSupplierId == supplierId
                                              && d.TrnStockOut.StockOutDate < dateStart.Date
                                              select new Models.MstInventoryReportModel
                                              {
                                                  Document = "Beg",
                                                  Id = "Beg-Out-" + d.Id,
                                                  InventoryDate = d.TrnStockOut.StockOutDate,
                                                  Supplier = d.MstItem.MstSupplier.Supplier,
                                                  Barcode = d.MstItem.BarCode,
                                                  ItemDescription = d.MstItem.ItemDescription,
                                                  BeginningQuantity = d.Quantity * -1,
                                                  InQuantity = 0,
                                                  ReturnQuantity = 0,
                                                  SoldQuantity = 0,
                                                  OutQuantity = 0,
                                                  EndingQuantity = 0,
                                                  Unit = d.MstUnit.Unit,
                                                  Cost = d.MstItem.Cost,
                                                  Amount = 0
                                              };

                var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningOutInventories.ToList());

                var currentInInventories = from d in db.TrnStockInLines
                                           where d.TrnStockIn.IsLocked == true
                                           && d.MstItem.DefaultSupplierId == supplierId
                                           && d.TrnStockIn.StockInDate >= dateStart.Date
                                           && d.TrnStockIn.StockInDate <= dateEnd.Date
                                           select new Models.MstInventoryReportModel
                                           {
                                               Document = "Cur",
                                               Id = "Cur-In-" + d.Id,
                                               InventoryDate = d.TrnStockIn.StockInDate,
                                               Supplier = d.MstItem.MstSupplier.Supplier,
                                               Barcode = d.MstItem.BarCode,
                                               ItemDescription = d.MstItem.ItemDescription,
                                               BeginningQuantity = 0,
                                               InQuantity = d.TrnStockIn.IsReturn == false ? d.Quantity : 0,
                                               ReturnQuantity = d.TrnStockIn.IsReturn == true ? d.Quantity : 0,
                                               SoldQuantity = 0,
                                               OutQuantity = 0,
                                               EndingQuantity = 0,
                                               Unit = d.MstUnit.Unit,
                                               Cost = d.MstItem.Cost,
                                               Amount = 0
                                           };

                var currentSoldInventories = from d in db.TrnSalesLines
                                             where d.TrnSale.IsLocked == true
                                             && d.TrnSale.IsCancelled == false
                                             && d.MstItem.DefaultSupplierId == supplierId
                                             && d.TrnSale.SalesDate >= dateStart.Date
                                             && d.TrnSale.SalesDate <= dateEnd.Date
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Cur",
                                                 Id = "Cur-Sold-" + d.Id,
                                                 InventoryDate = d.TrnSale.SalesDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
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

                var currentOutInventories = from d in db.TrnStockOutLines
                                            where d.TrnStockOut.IsLocked == true
                                            && d.MstItem.DefaultSupplierId == supplierId
                                            && d.TrnStockOut.StockOutDate >= dateStart.Date
                                            && d.TrnStockOut.StockOutDate <= dateEnd.Date
                                            select new Models.MstInventoryReportModel
                                            {
                                                Document = "Cur",
                                                Id = "Cur-Out-" + d.Id,
                                                InventoryDate = d.TrnStockOut.StockOutDate,
                                                Supplier = d.MstItem.MstSupplier.Supplier,
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

                var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentOutInventories.ToList());

                var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                if (unionInventories.Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.Supplier,
                                          d.Barcode,
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Models.MstInventoryReportModel
                                      {
                                          Supplier = g.Key.Supplier,
                                          Barcode = g.Key.Barcode,
                                          ItemDescription = g.Key.ItemDescription,
                                          BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                          InQuantity = g.Sum(s => s.InQuantity),
                                          ReturnQuantity = g.Sum(s => s.ReturnQuantity),
                                          SoldQuantity = g.Sum(s => s.SoldQuantity),
                                          OutQuantity = g.Sum(s => s.OutQuantity),
                                          EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity),
                                          Unit = g.Key.Unit,
                                          Cost = g.Key.Cost,
                                          Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity + s.ReturnQuantity) - s.SoldQuantity - s.OutQuantity)
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

        }

        private Task<List<DataGridViewModels.DgvInventoryReportListModel>> GetInventoryReportDataTask(Int32 supplierId, DateTime dateStart, DateTime dateEnd)
        {
            List<Models.MstInventoryReportModel> listInventoryReport = GetInventoryReportList(supplierId, dateStart, dateEnd);
            if (listInventoryReport.Any())
            {
                var items = from d in listInventoryReport
                            select new DataGridViewModels.DgvInventoryReportListModel
                            {
                                InventoryReportListSupplier = d.Supplier,
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

        }

        private void dateTimePickerDateEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            buttonGet.Text = "Loading...";
            buttonGet.Enabled = false;

            if (isInventoryFetched == false)
            {
                isInventoryFetched = true;
                CreateInventoryReportDataGridView();
            }
            else
            {
                UpdateInventoryReportDataSource();
            }
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            try
            {
                String filename = "";

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = "InventoryReport_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(filename))
                    {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    Int32 columnCount = dataGridViewInventoryReport.ColumnCount;

                    String columnNames = "";
                    String[] output = new String[dataGridViewInventoryReport.RowCount + 1];

                    for (Int32 i = 0; i < columnCount; i++)
                    {
                        columnNames += dataGridViewInventoryReport.Columns[i].Name.ToString().Substring(19) + ",";
                    }

                    output[0] += columnNames;
                    for (Int32 i = 1; (i - 1) < dataGridViewInventoryReport.RowCount; i++)
                    {
                        for (Int32 j = 0; j < columnCount; j++)
                        {
                            String data = "NA";
                            if (dataGridViewInventoryReport.Rows[i - 1].Cells[j].Value != null)
                            {
                                data = dataGridViewInventoryReport.Rows[i - 1].Cells[j].Value.ToString().Replace(",", "");
                            }

                            output[i] += data + ",";
                        }
                    }

                    File.WriteAllLines(sfd.FileName, output, Encoding.UTF8);

                    MessageBox.Show("Your file was successfully generated and its ready for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}