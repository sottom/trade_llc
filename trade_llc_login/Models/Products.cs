using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please provide a name for the product")]
        [DisplayName("Product Name")]
        [StringLength(255)]
        public string ProductName { get; set; }

        [DisplayName("Pickup Location")]
        [StringLength(255)]
        public string ProductPickupLocation { get; set; }

        [Required(ErrorMessage = "Please provide a product amount")]
        [DisplayName("Product Amount")]
        [StringLength(255)]
        public string ProductAmount { get; set; }

        [Required(ErrorMessage = "Please provide a selling price")]
        [DisplayName("Selling Price")]
        public decimal SellingPrice { get; set; }

        [DisplayName("Price After Commission")]
        public decimal PriceAfterCommission { get; set; }

        [DisplayName("Commission")]
        [StringLength(255)]
        public string Commission { get; set; }

        [DisplayName("Path to Image")]
        [StringLength(255)]
        public string ProductImg { get; set; }

        [ForeignKey("ProductTypes")]
        public int ProductTypeID { get; set; }
        public virtual ProductTypes ProductTypes { get; set; }

        //[ForeignKey("AspNetUsers")]
        public int SellerID { get; set; }
        //public virtual AspNetUsers AspNetUser { get; set; }

        //[ForeignKey("AspNetUsers")]
        public int? BuyerID { get; set; }
        //public virtual AspNetUsers AspNetUsers { get; set; }
    }
}