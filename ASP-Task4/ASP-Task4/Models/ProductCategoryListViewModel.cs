namespace ASP_Task4.Models
{
    public class ProductCategoryListViewModel
    {
        public IQueryable<ProductViewModel>? Products { get; set; }
        public IQueryable<CategoryViewModel>? Categories { get; set; }
    }
}
