using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using trade_llc_login.DAL;
using trade_llc_login.Models;

namespace trade_llc_login.Controllers
{
    public class ProductsController : Controller
    {
        private TradeContext db = new TradeContext();

        // GET: Products
        [Authorize]
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

            foreach (var com in product.Comments)
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
            Products product = db.products.Where(i => i.ProductID == 2).FirstOrDefault();

            product.Comments = db.comments.Where(i => i.ProductID == 2).ToList();

            foreach (var com in product.Comments)
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

        public ActionResult Miscellaneous() //Miscellaneous view
        {
            Products product = db.products.Where(i => i.ProductID == 3).FirstOrDefault();

            product.Comments = db.comments.Where(i => i.ProductID == 3).ToList();

            foreach (var com in product.Comments)
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

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(FormCollection form, int productId, string email, string productType)
        {

            string comment = form["comment"].Replace("'", "").Replace("\"", "");
            var userId = db.users.Where(i => i.UserEmail == email).FirstOrDefault().UserID;
            db.Database.ExecuteSqlCommand(
                $"INSERT INTO Comments (Comment, ProductID, UserID) " +
                $"VALUES ('{comment}', '{productId}', '{userId}')"
                );

            return RedirectToAction(productType);
        }

        [HttpGet]
        public ActionResult Reply(string productType)
        {

            return RedirectToAction(productType);
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> a4286941bf94701488d69623fccca6c36e9a7a90
        public ActionResult Reply(FormCollection form, int CommentID, string email, string productType)

        {
            string reply = form["reply"].Replace("'", "").Replace("\"", "");;
            
            
            if(email == null)
            {
                return RedirectToAction(productType);
            }

            var userId = db.users.Where(i => i.UserEmail == email).FirstOrDefault().UserID;

            db.Database.ExecuteSqlCommand(
                $"INSERT INTO CommentReplies (Reply, CommentID, UserID) " +
                $"VALUES ('{reply}', '{CommentID}', '{userId}')"
                );

            return RedirectToAction(productType);
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditReply(FormCollection form, int ReplyID, string productType)
        {
            string reply = form["editReply"].Replace("'", "").Replace("\"", "");;

            db.Database.ExecuteSqlCommand("UPDATE CommentReplies SET Reply = '" + reply + "' WHERE ReplyID = " + ReplyID);

            return RedirectToAction(productType);
        }
        

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditComment(FormCollection form, int CommentID, string productType)
        {
            string comments = form["editComment"].Replace("'", "").Replace("\"", "");
            db.Database.ExecuteSqlCommand(
                $"UPDATE Comments " +
                $"SET Comment = '{comments}' " +
                $"WHERE CommentID = {CommentID}"
                );

            return RedirectToAction(productType);
        }
    }
}