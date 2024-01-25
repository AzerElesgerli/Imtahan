using System.ComponentModel.DataAnnotations.Schema;

namespace ImtahanBEEXAM.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        [NotMapped]

        public IFormFile Photo { get; set; }
    }
}
