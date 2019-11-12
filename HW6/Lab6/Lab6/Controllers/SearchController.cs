using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab6.Models;
using Lab6.DAL;
using Lab6.Models.ViewModels;

namespace Lab6.Controllers
{
    public class SearchController : Controller
    {
        private WorldWideImportersContext db = new WorldWideImportersContext();

        // GET: Search
        public ActionResult SearchPage(string searchName)
        {
            var items = from db in db.StockItems select db;

            if (!String.IsNullOrEmpty(searchName))
            {
                items = items.Where(model => model.StockItemName.Contains(searchName));
            }
            // Current projects
            return View(db.StockItems.Where(model => model.StockItemName.Contains(searchName)));
            
        }


        public ActionResult Details(int ID)
        {
            StockItem stockItem = db.StockItems.Find(ID);
            ProductDetailViewModel viewModel = new ProductDetailViewModel(stockItem);
            return View(viewModel);
        }
    }
}