using System.ComponentModel.DataAnnotations;

namespace AceJobAgency.ViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
