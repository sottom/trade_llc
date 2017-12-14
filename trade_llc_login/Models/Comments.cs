using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        [DisplayName("Comment")]
        [StringLength(255)]
        public string Comment { get; set; }
        public IEnumerable<CommentReplies> reps { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public virtual Products Products { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
        public virtual Users Users  { get; set; }
    }
}