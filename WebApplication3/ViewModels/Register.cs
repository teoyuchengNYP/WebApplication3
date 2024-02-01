using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AceJobAgency.ViewModels
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string NRIC { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string BirthDate {  get; set; }

        [Required]
        //[RegularExpression(@"^.*\.(docx|pdf)$", ErrorMessage = "Invalid file format. Only .docx and .pdf are allowed.")]
        public string Resume {  get; set; }

        [Required]
        public string WhoAmI { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,}$",
            ErrorMessage = "Password must be at least 12 characters long and include at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string CustomValidationForPassword => Password;


    }
}
