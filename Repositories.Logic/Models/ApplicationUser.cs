using Repositories.Logic.Entities;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Logic.Models
{
    public class ApplicationUser : Entity
    {
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        [MinLength(2)]
        [MaxLength(28)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? AddressCorrespondence { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Phone number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Not a valid mobile phone number. Format ###-###-###")]
        public string? PhoneNumber { get; set; }

        public string? PhoneMobile { get; set; }
    }
}
