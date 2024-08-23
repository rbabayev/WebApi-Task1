using ASP_Task4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Task4.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }

        public List<Entities.Product> Products { get; set; }

        public string Info { get; set; }

        [BindProperty]
        public Entities.Product NewProduct { get; set; }

        [BindProperty]
        public Entities.Product EditProduct { get; set; }

        public void OnGet(string info = "")
        {
            LoadProducts();
            Info = info;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadProducts();
                return Page();
            }

            if (NewProduct.Id == 0)
            {
                _context.Products.Add(NewProduct);
                Info = $"{NewProduct.Name} added successfully";
            }

            _context.SaveChanges();
            return RedirectToPage("Index", new { info = Info });
        }

        public IActionResult OnPostEdit(int id)
        {
            EditProduct = _context.Products.Find(id);
            if (EditProduct != null)
            {
                LoadProducts();
                return Page();
            }

            return RedirectToPage("Index", new { info = "Product not found" });
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                LoadProducts();
                return Page();
            }

            var modifyProduct = _context.Products.Find(EditProduct.Id);
            if (modifyProduct != null)
            {
                modifyProduct.Name = EditProduct.Name;
                modifyProduct.Price = EditProduct.Price;
                _context.SaveChanges();
                Info = $"{EditProduct.Name} updated successfully";
            }

            return RedirectToPage("Index", new { info = Info });
        }

        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                Info = $"{product.Name} deleted successfully";
            }
            return RedirectToPage("Index", new { info = Info });
        }

        private void LoadProducts()
        {
            Products = _context.Products.ToList();
        }
    }
}
