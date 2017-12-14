using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Products product = db.products.Where(i => i.ProductID == 1).FirstOrDefault();

            product.Comments = db.comments.Where(i => i.ProductID == 1).ToList(); //adding all comments to the Comments IEnumerable

            foreach(var com in product.Comments)
            {
                com.reps = db.commentReplies.Where(i => i.CommentID == com.CommentID).ToList();

                foreach (var rep in com.reps)
                {
                    rep.Users = db.users.Where(i => i.UserID == rep.UserID).FirstOrDefault();
                }

                com.Users = db.users.Where(i => i.UserID == com.UserID).FirstOrDefault();
            }
            ViewBag.Cookie = global.cookieEmail;

            return View(product);
        }

        public ActionResult driedFruit() //driedFruit view
        {
            var products = db.products.Where(i => i.ProductName == "Bananas");

            ViewBag.Cookie = global.cookieEmail;

            return View(products);
        }

        public ActionResult Miscellaneous() //Miscellaneous view
        {
            var products = db.products.Where(i => i.ProductName == "Corn");

            ViewBag.Cookie = global.cookieEmail;
            return View(products);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(FormCollection form, int productId, string email)
        {
            string comment = form["comment"];
            var userId = db.users.Where(i => i.UserEmail == email).FirstOrDefault().UserID;
            db.Database.ExecuteSqlCommand(
                $"INSERT INTO Comments (Comment, ProductID, UserID) " +
                $"VALUES ('{comment}', '{productId}', '{userId}')"
                );

            return RedirectToAction("Nuts");
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Reply(FormCollection form, int CommentID, string email)
        {
            string reply = form["reply"];
            var userId = db.users.Where(i => i.UserEmail == email).FirstOrDefault().UserID;
            db.Database.ExecuteSqlCommand(
                $"INSERT INTO CommentReplies (Reply, CommentID, UserID) " +
                $"VALUES ('{reply}', '{CommentID}', '{userId}')"
                );

            return RedirectToAction("Nuts");
        }
    }
}