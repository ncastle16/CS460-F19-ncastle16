using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Documents;

namespace Lab6.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel(StockItem stockItem)
        {

            ItemName = stockItem.StockItemName;
            UnitPrice = stockItem.UnitPrice;
            TypicalWeightPerUnit = stockItem.TypicalWeightPerUnit;
            LeadTimeDays = stockItem.LeadTimeDays;
            ValidFrom = stockItem.ValidFrom;
            CustomFields = stockItem.CustomFields.Split('"')[3]; ;
            Tags = stockItem.Tags;
            Size = stockItem.Size;
            Company = stockItem.Supplier.SupplierName;
            Phone = stockItem.Supplier.PhoneNumber;
            Fax = stockItem.Supplier.FaxNumber;
            Website = stockItem.Supplier.WebsiteURL;
            Orders = stockItem.OrderLines.Where(i => i.StockItemID == stockItem.StockItemID).Count();
            GrossSales = stockItem.InvoiceLines.Where(i => i.StockItemID == stockItem.StockItemID).Sum(i => i.ExtendedPrice);
            GrossProfit = stockItem.InvoiceLines.Where(i => i.StockItemID == stockItem.StockItemID).Sum(i => i.LineProfit);
            
        // To get top 10
             var topPurchasers = (from il in stockItem.InvoiceLines
                             group new
                             {
                                 Quantity = il.Quantity
                             }
                                     by new
                                     {
                                         CustID = il.Invoice.Customer.CustomerID,
                                         CustName = il.Invoice.Customer.CustomerName,
                                     }
                             into CID
                             select new
                             {
                                 CNAme = CID.Key.CustName,
                                 Q = CID.Sum(x => x.Quantity)
                             }).OrderByDescending(o => o.Q).Take(10).ToList();

            IEnumerable<int> intresult = topPurchasers.Select(i => i.Q);
            IEnumerable<string> result = topPurchasers.Select(i => i.CNAme);
            List<int> qauntity = intresult.ToList();
            List<string> names = result.ToList();
            TopPurchaserInt = qauntity;
            TopPurchasers = names;
        }

        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime ValidFrom { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }

        public string Size { get; set; }

        //Supplier Profile
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Contact { get; set; }

        //Sales History Summary
        public int Orders { get; set; }
        public decimal GrossSales { get; set; }
        public decimal GrossProfit { get; set; }

        //Top Purchasers
        public List<string> TopPurchasers { get; set; }
        public List<int> TopPurchaserInt { get; set; }
    }
}