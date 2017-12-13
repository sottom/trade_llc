using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("Types_Users")]
    public class Types_Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeID { get; set; }
        public virtual Types Types { get; set; }

        public int UserID { get; set; }
        public virtual Users Users { get; set; }
    }
}