using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("CommentReplies")]
    public class CommentReplies
    {
        [Key]
        public int ReplyID { get; set; }

        [Required]
        [DisplayName("Reply")]
        [StringLength(255)]
        public string Reply { get; set; }

        [ForeignKey("Comments")]
        public int CommentID { get; set; }
        public virtual Comments Comments { get; set; }
    }
}