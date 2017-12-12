using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using trade_llc_login.Models;

namespace trade_llc_login.DAL
{
    public class TradeContext : DbContext
    {
        public TradeContext() : base("TradeContext")
        {
        }


        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Types> types { get; set; }
        public DbSet<Types_Users> types_users { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<CommentReplies> commentReplies { get; set; }
        public DbSet<IdentityUserLogin> identityUserLogin { get; set; }
        public DbSet<IdentityUserRole> identityUserRole { get; set; }

//the key in these aren't defined in DAL and that's giving my code issues
//IdentityUserLogin
//IdentityUserRole
//Types_Users



        // how do I connect the context to the user???
        public DbSet<ApplicationUser> applicationUser { get; set; }
    }
}