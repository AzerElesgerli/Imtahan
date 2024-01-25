using System.ComponentModel.DataAnnotations;

namespace ImtahanBEEXAM.Areas.Admin.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        [EmailAddress]
        public string EMail { get; set; }

        
        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}
