using System.ComponentModel.DataAnnotations;

namespace ImtahanBEEXAM.Areas.Admin.ViewModels.Product
{
    public class UpdateProductVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public IFormFile Photo { get; set; }
    }
}
