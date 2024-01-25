using ImtahanBEEXAM.Areas.Admin.ViewModels.Product;
using ImtahanBEEXAM.DAL;
using ImtahanBEEXAM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImtahanBEEXAM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            bool result = await _context.Products.AnyAsync(a => a.Name == vm.Name);
            if (result)
            {
                ModelState.AddModelError("Name ", "Bu adda Product movcuddur");
                    return View(vm);

            }
            Product product = new Product
            {
                Name = vm.Name,
                Description = vm.Description
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }




        [HttpPost]
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Product product = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
            if (product == null) return NotFound();


            UpdateProductVM update = new UpdateProductVM
            {

                Name = product.Name,
                Description = product.Description,

            };


            return View(update);


        }
        [HttpPost]
        public async Task<IActionResult> Update(int id ,UpdateProductVM productVM)
        {
            if (ModelState.IsValid) return View(productVM);
            if (id <= 0) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product==null)
            {
                return NotFound();
            }
            bool result = await _context.Products.AnyAsync(a => a.Name == productVM.Name);
            if(result==null)
            {
                ModelState.AddModelError("Name", "Bu adda mehsul movcuddur");
                return View(result);

            }
            product.Name = productVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            Product existed = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
            if (existed is null) return NotFound();
            _context.Products.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }


}



