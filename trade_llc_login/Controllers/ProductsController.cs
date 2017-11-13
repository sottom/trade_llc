using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trade_llc_login.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Beans",
                Value = "Beans"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Nuts",
                Value = "Nuts"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Dried Fruits",
                Value = "Dried Fruits"
            });

            ViewBag.listItems = listItems;
            return View();
        }
    }
}