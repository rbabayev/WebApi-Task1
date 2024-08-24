using ASP_Task3.Data;
using ASP_Task3.Entities;
using ASP_Task3.Models;
using ASP_Task3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Task3.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductDbContext _context;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ProductDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        public async Task<IActionResult> Index(string key = "")
        {
            var items = await _productService.GetAllByKey(key);
            return Ok(items);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(vm.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }


        [HttpGet]

        public async Task<ActionResult> Update(int id)
        {
            var product = _context.Products.SingleOrDefault(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var vm = new ProductAddViewModel
            {
                Product = product
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<ActionResult> Update(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(vm.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }


        [HttpGet]

        public async Task<ActionResult> Delete(int id)
        {
            var item = _context.Products.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                _context.Products.Remove(item);
            }

            return RedirectToAction("Index");
        }


    }
}
