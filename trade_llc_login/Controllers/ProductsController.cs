using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trade_llc_login.DAL;
using trade_llc_login.Models;

namespace trade_llc_login.Controllers
{
    public class ProductsController : Controller
    {
        private TradeContext db = new TradeContext();

        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<ProductTypes> types = db.Database.SqlQuery<ProductTypes>(
                "SELECT * " + 
                "FROM ProductTypes"
                );

            return View(types);
        }

        public ActionResult Nuts() //nuts view
        {
            ViewBag.ProductName = "Cashews";
            ViewBag.ProductCategory = "Nuts";
            ViewBag.ProductLocation = "Salt Lake City, UT";
            ViewBag.ProductImage = "../Content/tradellc_img/cashews.jpg";
            ViewBag.ProductAmount = "250lb";
            ViewBag.ProductPrice = "*Please contact Trade LLC for price.";
            return View();
        }

        public ActionResult driedFruit() //driedFruit view
        {
            ViewBag.ProductName = "Bananas";
            ViewBag.ProductCategory = "Dried Fruit";
            ViewBag.ProductLocation = "Quincy, IL";
            ViewBag.ProductImage = "../Content/tradellc_img/bananas.jpg";
            ViewBag.ProductAmount = "75lb";
            ViewBag.ProductPrice = "$1.25/lb";
            return View();
        }

        public ActionResult Miscellaneous() //Miscellaneous view
        {
            ViewBag.ProductName = "Corn";
            ViewBag.ProductCategory = "Miscellaneous";
            ViewBag.ProductLocation = "Des Moines, IA";
            ViewBag.ProductImage = "../Content/tradellc_img/corn.png";
            ViewBag.ProductAmount = "500lb";
            ViewBag.ProductPrice = "*Please contact Trade LLC for price.";
            return View();
        }


    }
}