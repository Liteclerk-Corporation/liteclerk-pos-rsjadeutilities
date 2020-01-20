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
    public partial class TrnInventoryDetails : Form
    {
        public Data.posDataContext db = new Data.posDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        private static List<DataGridViewModels.DgvInventoryDetailsListModel> inventoryDetailsListData = new List<DataGridViewModels.DgvInventoryDetailsListModel>();
        private static Int32 pageNumber = 1, pageSize = 50;
        private PagedList<DataGridViewModels.DgvInventoryDetailsListModel> inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, pageNumber, pageSize);

        public TrnInventoryDetails(String transactionType, Int32 itemId, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            var item = from d in db.MstItems
                       where d.Id == itemId
                       select d;

            if (item.Any())
            {
                textBoxItemName.Text = item.FirstOrDefault().ItemDescription;
            }

            CreateInventoryDetailsDataGridView(transactionType, itemId, startDate, endDate);
        }

        public void UpdateInventoryDetailsDataSource(String transactionType, Int32 itemId, DateTime startDate, DateTime endDate)
        {
            SetInventoryDetailsDataSourceAsync(transactionType, itemId, startDate, endDate);
        }

        public async void SetInventoryDetailsDataSourceAsync(String transactionType, Int32 itemId, DateTime startDate, DateTime endDate)
        {
            List<DataGridViewModels.DgvInventoryDetailsListModel> getInventoryDetailsData = await GetInventoryDetailsDataTask(transactionType, itemId, startDate, endDate);
            if (getInventoryDetailsData.Any())
            {
                inventoryDetailsListData = getInventoryDetailsData;
                inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, pageNumber, pageSize);

                if (inventoryDetailsListPageList.PageCount == 1)
                {
                    buttonInventoryDetailsPageListFirst.Enabled = false;
                    buttonInventoryDetailsPageListPrevious.Enabled = false;
                    buttonInventoryDetailsPageListNext.Enabled = false;
                    buttonInventoryDetailsPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonInventoryDetailsPageListFirst.Enabled = false;
                    buttonInventoryDetailsPageListPrevious.Enabled = false;
                    buttonInventoryDetailsPageListNext.Enabled = true;
                    buttonInventoryDetailsPageListLast.Enabled = true;
                }
                else if (pageNumber == inventoryDetailsListPageList.PageCount)
                {
                    buttonInventoryDetailsPageListFirst.Enabled = true;
                    buttonInventoryDetailsPageListPrevious.Enabled = true;
                    buttonInventoryDetailsPageListNext.Enabled = false;
                    buttonInventoryDetailsPageListLast.Enabled = false;
                }
                else
                {
                    buttonInventoryDetailsPageListFirst.Enabled = true;
                    buttonInventoryDetailsPageListPrevious.Enabled = true;
                    buttonInventoryDetailsPageListNext.Enabled = true;
                    buttonInventoryDetailsPageListLast.Enabled = true;
                }

                textBoxInventoryDetailsPageNumber.Text = pageNumber + " / " + inventoryDetailsListPageList.PageCount;
                bindingSourceInventoryDetails.DataSource = inventoryDetailsListPageList;
            }
            else
            {
                buttonInventoryDetailsPageListFirst.Enabled = false;
                buttonInventoryDetailsPageListPrevious.Enabled = false;
                buttonInventoryDetailsPageListNext.Enabled = false;
                buttonInventoryDetailsPageListLast.Enabled = false;

                pageNumber = 1;

                inventoryDetailsListData = new List<DataGridViewModels.DgvInventoryDetailsListModel>();
                bindingSourceInventoryDetails.Clear();
                textBoxInventoryDetailsPageNumber.Text = "1 / 1";
            }
        }

        private List<Models.MstInventoryDetailsModel> GetInventoryDetailsList(String transactionType, Int32 itemId, DateTime startDate, DateTime endDate)
        {
            List<Models.MstInventoryDetailsModel> inventoryDetails = new List<Models.MstInventoryDetailsModel>();

            switch (transactionType)
            {
                case "IN":
                    var stockInItems = from d in db.TrnStockInLines
                                       where d.TrnStockIn.IsLocked == true
                                       && d.TrnStockIn.StockInDate >= startDate.Date
                                       && d.TrnStockIn.StockInDate <= endDate.Date
                                       && d.TrnStockIn.IsReturn == false
                                       && d.ItemId == itemId
                                       && d.MstItem.IsInventory == true
                                       && d.MstItem.IsLocked == true
                                       select d;

                    if (stockInItems.Any())
                    {
                        foreach (var stockInItem in stockInItems)
                        {
                            inventoryDetails.Add(new Models.MstInventoryDetailsModel()
                            {
                                ReferenceNumber = stockInItem.TrnStockIn.StockInNumber,
                                ReferenceDate = stockInItem.TrnStockIn.StockInDate,
                                Remarks = stockInItem.TrnStockIn.Remarks,
                                Quantity = stockInItem.Quantity
                            });
                        }
                    }

                    break;
                case "RETURN":
                    var returnItems = from d in db.TrnStockInLines
                                      where d.TrnStockIn.IsLocked == true
                                      && d.TrnStockIn.StockInDate >= startDate.Date
                                      && d.TrnStockIn.StockInDate <= endDate.Date
                                      && d.TrnStockIn.IsReturn == true
                                      && d.ItemId == itemId
                                      && d.MstItem.IsInventory == true
                                      && d.MstItem.IsLocked == true
                                      select d;

                    if (returnItems.Any())
                    {
                        foreach (var returnItem in returnItems)
                        {
                            inventoryDetails.Add(new Models.MstInventoryDetailsModel()
                            {
                                ReferenceNumber = returnItem.TrnStockIn.StockInNumber,
                                ReferenceDate = returnItem.TrnStockIn.StockInDate,
                                Remarks = returnItem.TrnStockIn.Remarks,
                                Quantity = returnItem.Quantity
                            });
                        }
                    }

                    break;
                case "SOLD":
                    var soldItems = from d in db.TrnSalesLines
                                    where d.TrnSale.IsLocked == true
                                    && d.TrnSale.IsCancelled == false
                                    && d.TrnSale.SalesDate >= startDate.Date
                                    && d.TrnSale.SalesDate <= endDate.Date
                                    && d.ItemId == itemId
                                    && d.MstItem.IsInventory == true
                                    && d.MstItem.IsLocked == true
                                    select d;

                    foreach (var soldItem in soldItems)
                    {
                        inventoryDetails.Add(new Models.MstInventoryDetailsModel()
                        {
                            ReferenceNumber = soldItem.TrnSale.SalesNumber,
                            ReferenceDate = soldItem.TrnSale.SalesDate,
                            Remarks = soldItem.TrnSale.Remarks,
                            Quantity = soldItem.Quantity
                        });
                    }

                    var soldComponents = new List<Models.MstInventoryDetailsModel>();

                    var soldItemComponents = from d in db.TrnSalesLines
                                             where d.TrnSale.IsLocked == true
                                             && d.TrnSale.IsCancelled == false
                                             && d.TrnSale.SalesDate >= startDate.Date
                                             && d.TrnSale.SalesDate <= endDate.Date
                                             && d.MstItem.IsInventory == false
                                             && d.MstItem.MstItemComponents.Any() == true
                                             && d.MstItem.IsLocked == true
                                             select d;

                    if (soldItemComponents.ToList().Any() == true)
                    {
                        foreach (var currentSoldComponent in soldItemComponents.ToList())
                        {
                            var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    inventoryDetails.Add(new Models.MstInventoryDetailsModel()
                                    {
                                        ReferenceNumber = currentSoldComponent.TrnSale.SalesNumber,
                                        ReferenceDate = currentSoldComponent.TrnSale.SalesDate,
                                        Remarks = currentSoldComponent.TrnSale.Remarks,
                                        Quantity = itemComponent.Quantity * currentSoldComponent.Quantity
                                    });
                                }
                            }
                        }
                    }

                    break;
                case "OT":
                    var stockOutItems = from d in db.TrnStockOutLines
                                        where d.TrnStockOut.IsLocked == true
                                        && d.TrnStockOut.StockOutDate >= startDate.Date
                                        && d.TrnStockOut.StockOutDate <= endDate.Date
                                        && d.ItemId == itemId
                                        && d.MstItem.IsInventory == true
                                        && d.MstItem.IsLocked == true
                                        select d;

                    if (stockOutItems.Any())
                    {
                        foreach (var stockOutItem in stockOutItems)
                        {
                            inventoryDetails.Add(new Models.MstInventoryDetailsModel()
                            {
                                ReferenceNumber = stockOutItem.TrnStockOut.StockOutNumber,
                                ReferenceDate = stockOutItem.TrnStockOut.StockOutDate,
                                Remarks = stockOutItem.TrnStockOut.Remarks,
                                Quantity = stockOutItem.Quantity
                            });
                        }
                    }

                    break;
                default:
                    inventoryDetails = new List<Models.MstInventoryDetailsModel>();
                    break;
            }

            return inventoryDetails.ToList();
        }

        private Task<List<DataGridViewModels.DgvInventoryDetailsListModel>> GetInventoryDetailsDataTask(String transactionType, Int32 itemId, DateTime startDate, DateTime endDate)
        {
            List<Models.MstInventoryDetailsModel> listInventoryDetails = GetInventoryDetailsList(transactionType, itemId, startDate, endDate);
            if (listInventoryDetails.Any())
            {
                var items = from d in listInventoryDetails
                            select new DataGridViewModels.DgvInventoryDetailsListModel
                            {
                                ColumnReferenceNumber = d.ReferenceNumber,
                                ColumnReferenceDate = d.ReferenceDate.ToShortDateString(),
                                ColumnRemarks = d.Remarks,
                                ColumnQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnSpace = ""
                            };

                Decimal totalQuantity = listInventoryDetails.Sum(d => d.Quantity);
                textBoxTotalQuantity.Text = totalQuantity.ToString("#,##0.00");

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<DataGridViewModels.DgvInventoryDetailsListModel>());
            }
        }

        public void CreateInventoryDetailsDataGridView(String transactionType, Int32 ItemId, DateTime StartDate, DateTime EndDate)
        {
            UpdateInventoryDetailsDataSource(transactionType, ItemId, StartDate, EndDate);
            dataGridViewInventoryDetails.DataSource = bindingSourceInventoryDetails;
        }

        private void buttonInventoryDetailsPageListFirst_Click(object sender, EventArgs e)
        {
            inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, 1, pageSize);
            bindingSourceInventoryDetails.DataSource = inventoryDetailsListPageList;

            buttonInventoryDetailsPageListFirst.Enabled = false;
            buttonInventoryDetailsPageListPrevious.Enabled = false;
            buttonInventoryDetailsPageListNext.Enabled = true;
            buttonInventoryDetailsPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxInventoryDetailsPageNumber.Text = pageNumber + " / " + inventoryDetailsListPageList.PageCount;
        }

        private void buttonInventoryDetailsPageListPrevious_Click(object sender, EventArgs e)
        {
            if (inventoryDetailsListPageList.HasPreviousPage == true)
            {
                inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, --pageNumber, pageSize);
                bindingSourceInventoryDetails.DataSource = inventoryDetailsListPageList;
            }

            buttonInventoryDetailsPageListNext.Enabled = true;
            buttonInventoryDetailsPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonInventoryDetailsPageListFirst.Enabled = false;
                buttonInventoryDetailsPageListPrevious.Enabled = false;
            }

            textBoxInventoryDetailsPageNumber.Text = pageNumber + " / " + inventoryDetailsListPageList.PageCount;
        }

        private void buttonInventoryDetailsPageListNext_Click(object sender, EventArgs e)
        {
            if (inventoryDetailsListPageList.HasNextPage == true)
            {
                inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, ++pageNumber, pageSize);
                bindingSourceInventoryDetails.DataSource = inventoryDetailsListPageList;
            }

            buttonInventoryDetailsPageListFirst.Enabled = true;
            buttonInventoryDetailsPageListPrevious.Enabled = true;

            if (pageNumber == inventoryDetailsListPageList.PageCount)
            {
                buttonInventoryDetailsPageListNext.Enabled = false;
                buttonInventoryDetailsPageListLast.Enabled = false;
            }

            textBoxInventoryDetailsPageNumber.Text = pageNumber + " / " + inventoryDetailsListPageList.PageCount;
        }

        private void buttonInventoryDetailsPageListLast_Click(object sender, EventArgs e)
        {
            inventoryDetailsListPageList = new PagedList<DataGridViewModels.DgvInventoryDetailsListModel>(inventoryDetailsListData, inventoryDetailsListPageList.PageCount, pageSize);
            bindingSourceInventoryDetails.DataSource = inventoryDetailsListPageList;

            buttonInventoryDetailsPageListFirst.Enabled = true;
            buttonInventoryDetailsPageListPrevious.Enabled = true;
            buttonInventoryDetailsPageListNext.Enabled = false;
            buttonInventoryDetailsPageListLast.Enabled = false;

            pageNumber = inventoryDetailsListPageList.PageCount;
            textBoxInventoryDetailsPageNumber.Text = pageNumber + " / " + inventoryDetailsListPageList.PageCount;
        }
    }
}
