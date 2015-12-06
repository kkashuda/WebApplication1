using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmailFormModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Key]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Your Email")]
        [EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Previous Work Experience")]
        public string WorkExperience { get; set; }

        [Required]
        [Display(Name = "Relevant Skills")]
        public string Skills { get; set; }

        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        //public string EmployerEmail { get; set; }
    }
}