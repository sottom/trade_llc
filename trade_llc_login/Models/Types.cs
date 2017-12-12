using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("Types")]
    public class Types
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        [DisplayName("User Type")]
        [StringLength(255)]
        public string Type { get; set; }
    }
}