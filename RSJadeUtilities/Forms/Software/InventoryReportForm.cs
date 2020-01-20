using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
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
                                             && d.MstItem.IsInventory == true
                                             && d.MstItem.IsLocked == true
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Beg",
                                                 Id = "Beg-In-" + d.Id,
                                                 InventoryDate = d.TrnStockIn.StockInDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 ItemId = d.ItemId,
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
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Models.MstInventoryReportModel
                                               {
                                                   Document = "Beg",
                                                   Id = "Beg-Sold-" + d.Id,
                                                   InventoryDate = d.TrnSale.SalesDate,
                                                   Supplier = d.MstItem.MstSupplier.Supplier,
                                                   ItemId = d.ItemId,
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

                List<Models.MstInventoryReportModel> beginningSoldComponentInventories = new List<Models.MstInventoryReportModel>();

                var beginningSoldComponents = from d in db.TrnSalesLines
                                              where d.TrnSale.IsLocked == true
                                              && d.TrnSale.IsCancelled == false
                                              && d.TrnSale.SalesDate < dateStart.Date
                                              && d.MstItem.IsInventory == false
                                              && d.MstItem.MstItemComponents.Any() == true
                                              && d.MstItem.IsLocked == true
                                              select d;

                if (beginningSoldComponents.ToList().Any() == true)
                {
                    foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                    {
                        var itemComponents = beginningSoldComponent.MstItem.MstItemComponents;
                        if (itemComponents.Any() == true)
                        {
                            foreach (var itemComponent in itemComponents.ToList())
                            {
                                beginningSoldComponentInventories.Add(new Models.MstInventoryReportModel()
                                {
                                    Document = "Cur",
                                    Id = "Beg-Sold-Component" + itemComponent.Id,
                                    InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                    Supplier = itemComponent.MstItem1.MstSupplier1.Supplier,
                                    ItemId = itemComponent.ComponentItemId,
                                    Barcode = itemComponent.MstItem1.BarCode,
                                    ItemDescription = itemComponent.MstItem1.ItemDescription,
                                    BeginningQuantity = 0,
                                    InQuantity = 0,
                                    ReturnQuantity = 0,
                                    SoldQuantity = itemComponent.Quantity * beginningSoldComponent.Quantity,
                                    OutQuantity = 0,
                                    EndingQuantity = 0,
                                    Unit = itemComponent.MstItem1.MstUnit.Unit,
                                    Cost = itemComponent.MstItem1.Cost,
                                    Amount = 0
                                });
                            }
                        }
                    }
                }

                var beginningOutInventories = from d in db.TrnStockOutLines
                                              where d.TrnStockOut.IsLocked == true
                                              && d.TrnStockOut.StockOutDate < dateStart.Date
                                              && d.MstItem.IsInventory == true
                                              && d.MstItem.IsLocked == true
                                              select new Models.MstInventoryReportModel
                                              {
                                                  Document = "Beg",
                                                  Id = "Beg-Out-" + d.Id,
                                                  InventoryDate = d.TrnStockOut.StockOutDate,
                                                  Supplier = d.MstItem.MstSupplier.Supplier,
                                                  ItemId = d.ItemId,
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

                var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                var currentInInventories = from d in db.TrnStockInLines
                                           where d.TrnStockIn.IsLocked == true
                                           && d.TrnStockIn.StockInDate >= dateStart.Date
                                           && d.TrnStockIn.StockInDate <= dateEnd.Date
                                           && d.MstItem.IsInventory == true
                                           && d.MstItem.IsLocked == true
                                           select new Models.MstInventoryReportModel
                                           {
                                               Document = "Cur",
                                               Id = "Cur-In-" + d.Id,
                                               InventoryDate = d.TrnStockIn.StockInDate,
                                               Supplier = d.MstItem.MstSupplier.Supplier,
                                               ItemId = d.ItemId,
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
                                             && d.MstItem.IsInventory == true
                                             && d.MstItem.IsLocked == true
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Cur",
                                                 Id = "Cur-Sold-" + d.Id,
                                                 InventoryDate = d.TrnSale.SalesDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 ItemId = d.ItemId,
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

                List<Models.MstInventoryReportModel> currentSoldComponentInventories = new List<Models.MstInventoryReportModel>();

                var currentSoldComponents = from d in db.TrnSalesLines
                                            where d.TrnSale.IsLocked == true
                                            && d.TrnSale.IsCancelled == false
                                            && d.TrnSale.SalesDate >= dateStart.Date
                                            && d.TrnSale.SalesDate <= dateEnd.Date
                                            && d.MstItem.IsInventory == false
                                            && d.MstItem.MstItemComponents.Any() == true
                                            && d.MstItem.IsLocked == true
                                            select d;

                if (currentSoldComponents.ToList().Any() == true)
                {
                    foreach (var currentSoldComponent in currentSoldComponents.ToList())
                    {
                        var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                        if (itemComponents.Any() == true)
                        {
                            foreach (var itemComponent in itemComponents.ToList())
                            {
                                currentSoldComponentInventories.Add(new Models.MstInventoryReportModel()
                                {
                                    Document = "Cur",
                                    Id = "Cur-Sold-Component" + itemComponent.Id,
                                    InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                    Supplier = itemComponent.MstItem1.MstSupplier1.Supplier,
                                    ItemId = itemComponent.ComponentItemId,
                                    Barcode = itemComponent.MstItem1.BarCode,
                                    ItemDescription = itemComponent.MstItem1.ItemDescription,
                                    BeginningQuantity = 0,
                                    InQuantity = 0,
                                    ReturnQuantity = 0,
                                    SoldQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                    OutQuantity = 0,
                                    EndingQuantity = 0,
                                    Unit = itemComponent.MstItem1.MstUnit.Unit,
                                    Cost = itemComponent.MstItem1.Cost,
                                    Amount = 0
                                });
                            }
                        }
                    }
                }

                var currentOutInventories = from d in db.TrnStockOutLines
                                            where d.TrnStockOut.IsLocked == true
                                            && d.TrnStockOut.StockOutDate >= dateStart.Date
                                            && d.TrnStockOut.StockOutDate <= dateEnd.Date
                                            && d.MstItem.IsInventory == true
                                            && d.MstItem.IsLocked == true
                                            select new Models.MstInventoryReportModel
                                            {
                                                Document = "Cur",
                                                Id = "Cur-Out-" + d.Id,
                                                InventoryDate = d.TrnStockOut.StockOutDate,
                                                Supplier = d.MstItem.MstSupplier.Supplier,
                                                ItemId = d.ItemId,
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

                var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                if (unionInventories.Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.Supplier,
                                          d.ItemId,
                                          d.Barcode,
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Models.MstInventoryReportModel
                                      {
                                          Supplier = g.Key.Supplier,
                                          ItemId = g.Key.ItemId,
                                          Barcode = g.Key.Barcode,
                                          ItemDescription = g.Key.ItemDescription,
                                          BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                          InQuantity = g.Sum(s => s.InQuantity),
                                          ReturnQuantity = g.Sum(s => s.ReturnQuantity),
                                          SoldQuantity = g.Sum(s => s.SoldQuantity) * -1,
                                          OutQuantity = g.Sum(s => s.OutQuantity) * -1,
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
                                             && d.TrnStockIn.StockInDate < dateStart.Date
                                             && d.MstItem.DefaultSupplierId == supplierId
                                             && d.MstItem.IsInventory == true
                                             && d.MstItem.IsLocked == true
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Beg",
                                                 Id = "Beg-In-" + d.Id,
                                                 InventoryDate = d.TrnStockIn.StockInDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 ItemId = d.ItemId,
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
                                               && d.MstItem.DefaultSupplierId == supplierId
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Models.MstInventoryReportModel
                                               {
                                                   Document = "Beg",
                                                   Id = "Beg-Sold-" + d.Id,
                                                   InventoryDate = d.TrnSale.SalesDate,
                                                   Supplier = d.MstItem.MstSupplier.Supplier,
                                                   ItemId = d.ItemId,
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

                List<Models.MstInventoryReportModel> beginningSoldComponentInventories = new List<Models.MstInventoryReportModel>();

                var beginningSoldComponents = from d in db.TrnSalesLines
                                              where d.TrnSale.IsLocked == true
                                              && d.TrnSale.IsCancelled == false
                                              && d.TrnSale.SalesDate < dateStart.Date
                                              && d.MstItem.IsInventory == false
                                              && d.MstItem.MstItemComponents.Where(c => c.MstItem1.DefaultSupplierId == supplierId).Any() == true
                                              && d.MstItem.IsLocked == true
                                              select d;

                if (beginningSoldComponents.ToList().Any() == true)
                {
                    foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                    {
                        var itemComponents = beginningSoldComponent.MstItem.MstItemComponents.Where(c => c.MstItem1.DefaultSupplierId == supplierId);
                        if (itemComponents.Any() == true)
                        {
                            foreach (var itemComponent in itemComponents.ToList())
                            {
                                beginningSoldComponentInventories.Add(new Models.MstInventoryReportModel()
                                {
                                    Document = "Cur",
                                    Id = "Beg-Sold-Component" + itemComponent.Id,
                                    InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                    Supplier = itemComponent.MstItem1.MstSupplier1.Supplier,
                                    ItemId = itemComponent.ComponentItemId,
                                    Barcode = itemComponent.MstItem1.BarCode,
                                    ItemDescription = itemComponent.MstItem1.ItemDescription,
                                    BeginningQuantity = 0,
                                    InQuantity = 0,
                                    ReturnQuantity = 0,
                                    SoldQuantity = itemComponent.Quantity * beginningSoldComponent.Quantity,
                                    OutQuantity = 0,
                                    EndingQuantity = 0,
                                    Unit = itemComponent.MstItem1.MstUnit.Unit,
                                    Cost = itemComponent.MstItem1.Cost,
                                    Amount = 0
                                });
                            }
                        }
                    }
                }

                var beginningOutInventories = from d in db.TrnStockOutLines
                                              where d.TrnStockOut.IsLocked == true
                                              && d.TrnStockOut.StockOutDate < dateStart.Date
                                              && d.MstItem.DefaultSupplierId == supplierId
                                              && d.MstItem.IsInventory == true
                                              && d.MstItem.IsLocked == true
                                              select new Models.MstInventoryReportModel
                                              {
                                                  Document = "Beg",
                                                  Id = "Beg-Out-" + d.Id,
                                                  InventoryDate = d.TrnStockOut.StockOutDate,
                                                  Supplier = d.MstItem.MstSupplier.Supplier,
                                                  ItemId = d.ItemId,
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

                var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                var currentInInventories = from d in db.TrnStockInLines
                                           where d.TrnStockIn.IsLocked == true
                                           && d.TrnStockIn.StockInDate >= dateStart.Date
                                           && d.TrnStockIn.StockInDate <= dateEnd.Date
                                           && d.MstItem.DefaultSupplierId == supplierId
                                           && d.MstItem.IsInventory == true
                                           && d.MstItem.IsLocked == true
                                           select new Models.MstInventoryReportModel
                                           {
                                               Document = "Cur",
                                               Id = "Cur-In-" + d.Id,
                                               InventoryDate = d.TrnStockIn.StockInDate,
                                               Supplier = d.MstItem.MstSupplier.Supplier,
                                               ItemId = d.ItemId,
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
                                             && d.MstItem.DefaultSupplierId == supplierId
                                             && d.MstItem.IsInventory == true
                                             && d.MstItem.IsLocked == true
                                             select new Models.MstInventoryReportModel
                                             {
                                                 Document = "Cur",
                                                 Id = "Cur-Sold-" + d.Id,
                                                 InventoryDate = d.TrnSale.SalesDate,
                                                 Supplier = d.MstItem.MstSupplier.Supplier,
                                                 ItemId = d.ItemId,
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

                List<Models.MstInventoryReportModel> currentSoldComponentInventories = new List<Models.MstInventoryReportModel>();

                var currentSoldComponents = from d in db.TrnSalesLines
                                            where d.TrnSale.IsLocked == true
                                            && d.TrnSale.IsCancelled == false
                                            && d.TrnSale.SalesDate >= dateStart.Date
                                            && d.TrnSale.SalesDate <= dateEnd.Date
                                            && d.MstItem.IsInventory == false
                                            && d.MstItem.MstItemComponents.Where(c => c.MstItem1.DefaultSupplierId == supplierId).Any() == true
                                            && d.MstItem.IsLocked == true
                                            select d;

                if (currentSoldComponents.ToList().Any() == true)
                {
                    foreach (var currentSoldComponent in currentSoldComponents.ToList())
                    {
                        var itemComponents = currentSoldComponent.MstItem.MstItemComponents.Where(c => c.MstItem1.DefaultSupplierId == supplierId);
                        if (itemComponents.Any() == true)
                        {
                            foreach (var itemComponent in itemComponents.ToList())
                            {
                                currentSoldComponentInventories.Add(new Models.MstInventoryReportModel()
                                {
                                    Document = "Cur",
                                    Id = "Cur-Sold-Component" + itemComponent.Id,
                                    InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                    Supplier = itemComponent.MstItem1.MstSupplier1.Supplier,
                                    ItemId = itemComponent.ComponentItemId,
                                    Barcode = itemComponent.MstItem1.BarCode,
                                    ItemDescription = itemComponent.MstItem1.ItemDescription,
                                    BeginningQuantity = 0,
                                    InQuantity = 0,
                                    ReturnQuantity = 0,
                                    SoldQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                    OutQuantity = 0,
                                    EndingQuantity = 0,
                                    Unit = itemComponent.MstItem1.MstUnit.Unit,
                                    Cost = itemComponent.MstItem1.Cost,
                                    Amount = 0
                                });
                            }
                        }
                    }
                }

                var currentOutInventories = from d in db.TrnStockOutLines
                                            where d.TrnStockOut.IsLocked == true
                                            && d.TrnStockOut.StockOutDate >= dateStart.Date
                                            && d.TrnStockOut.StockOutDate <= dateEnd.Date
                                            && d.MstItem.DefaultSupplierId == supplierId
                                            && d.MstItem.IsInventory == true
                                            && d.MstItem.IsLocked == true
                                            select new Models.MstInventoryReportModel
                                            {
                                                Document = "Cur",
                                                Id = "Cur-Out-" + d.Id,
                                                InventoryDate = d.TrnStockOut.StockOutDate,
                                                Supplier = d.MstItem.MstSupplier.Supplier,
                                                ItemId = d.ItemId,
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

                var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                if (unionInventories.Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.Supplier,
                                          d.ItemId,
                                          d.Barcode,
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Models.MstInventoryReportModel
                                      {
                                          Supplier = g.Key.Supplier,
                                          ItemId = g.Key.ItemId,
                                          Barcode = g.Key.Barcode,
                                          ItemDescription = g.Key.ItemDescription,
                                          BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                          InQuantity = g.Sum(s => s.InQuantity),
                                          ReturnQuantity = g.Sum(s => s.ReturnQuantity),
                                          SoldQuantity = g.Sum(s => s.SoldQuantity) * -1,
                                          OutQuantity = g.Sum(s => s.OutQuantity) * -1,
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
                if (e.RowIndex > -1)
                {

                }

                if (e.RowIndex > -1 && dataGridViewInventoryReport.CurrentCell.ColumnIndex == dataGridViewInventoryReport.Columns["InventoryReportListInQuantity"].Index)
                {

                }

                if (e.RowIndex > -1 && dataGridViewInventoryReport.CurrentCell.ColumnIndex == dataGridViewInventoryReport.Columns["InventoryReportListReturnQuantity"].Index)
                {

                }

                if (e.RowIndex > -1 && dataGridViewInventoryReport.CurrentCell.ColumnIndex == dataGridViewInventoryReport.Columns["InventoryReportListSoldQuantity"].Index)
                {

                }

                if (e.RowIndex > -1 && dataGridViewInventoryReport.CurrentCell.ColumnIndex == dataGridViewInventoryReport.Columns["InventoryReportListOutQuantity"].Index)
                {

                }
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
                DialogResult dialogResult = folderBrowserDialogGenerateCSV.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    String[] header = {
                        "Supplier",
                        "Barcode",
                        "Item Description",
                        "Beg",
                        "In",
                        "Return",
                        "Sold",
                        "Out",
                        "End",
                        "Unit"
                    };
                    csv.AppendLine(String.Join(",", header));

                    if (inventoryReportListData.Any())
                    {
                        foreach (var collection in inventoryReportListData.OrderBy(d => d.InventoryReportListSupplier))
                        {
                            //String begQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListBeginningQuantity) != 0)
                            //{
                            //    begQuantity = collection.InventoryReportListBeginningQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            //String inQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListInQuantity) != 0)
                            //{
                            //    inQuantity = collection.InventoryReportListInQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            //String returnQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListReturnQuantity) != 0)
                            //{
                            //    returnQuantity = collection.InventoryReportListReturnQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            //String soldQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListSoldQuantity) != 0)
                            //{
                            //    soldQuantity = collection.InventoryReportListSoldQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            //String outQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListOutQuantity) != 0)
                            //{
                            //    outQuantity = collection.InventoryReportListOutQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            //String endQuantity = "-";
                            //if (Convert.ToDecimal(collection.InventoryReportListEndingQuantity) != 0)
                            //{
                            //    endQuantity = collection.InventoryReportListEndingQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //}

                            String[] data = {
                                collection.InventoryReportListSupplier.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListBarcode.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListItemDescription.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListBeginningQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListInQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListReturnQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListSoldQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListOutQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListEndingQuantity.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty),
                                collection.InventoryReportListUnit.Replace(",", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty)
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\InventoryReport_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}