using System.ComponentModel.DataAnnotations;

namespace ImtahanBEEXAM.Areas.Admin.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        public string Surname { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }




    }
}
