using System.ComponentModel.DataAnnotations;

namespace KroyBikroyBackend.Dto
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]

        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
