namespace ImtahanBEEXAM.Areas.Admin.ViewModels.Product
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
