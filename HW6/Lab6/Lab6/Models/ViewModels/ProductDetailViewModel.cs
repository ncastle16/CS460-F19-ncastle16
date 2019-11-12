using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            CustomFields = stockItem.CustomFields;
            Tags = stockItem.Tags;
            Size = stockItem.Size;
            Company = stockItem.Brand;
        }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime ValidFrom { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }

        public string Size { get; set; }


        public string Company { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Contact { get; set; }

    }
}