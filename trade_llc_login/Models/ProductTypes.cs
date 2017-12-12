using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("ProductTypes")]
    public class ProductTypes
    {
        [Key]
        public int ProductTypeID { get; set; }

        [Required]
        [DisplayName("Product Type")]
        [StringLength(255)]
        public string ProductType { get; set; }
    }
}