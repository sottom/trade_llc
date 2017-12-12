using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trade_llc_login.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [DisplayName("First Name")]
        [StringLength(255)]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [DisplayName("Last Name")]
        [StringLength(255)]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is requires")]
        [DisplayName("Password")]
        [StringLength(255)]
        public string UserPassword { get; set; }

        public string hello;

    }
}