using System.ComponentModel.DataAnnotations;

namespace YourApp.Models
{
    public class AddUserModel
    {
        public int Id { get; set; } // For database identity

        [Required]
        [Display(Name = "Branch")]
        public string Branch { get; set; }

        [Required]
        [Display(Name = "Counter")]
        public string Counter { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "नेपाली नाम")] // Nepali Name
        public string NepaliName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Other Contact")]
        public string OtherContact { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password Option")]
        public string PasswordOption { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}
