using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Your name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Your email address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Enter a message")]
        public string Message { get; set; }
    }
}