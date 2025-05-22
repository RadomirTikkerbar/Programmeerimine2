using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Product> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }
        public async Task<PagedResult<Product>> List(int page, int pageSize, ProductSearch search = null)
        {
            var query = _context.Product.AsQueryable();

            search = search ?? new ProductSearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Name.Contains(search.Keyword));
            }

            return await query
                .OrderBy(list => list.Name)
                .GetPagedAsync(page, pageSize);
        }
        public async Task Save(Product list)
        {
            if (list.Id == 0)
            {
                _context.Product.Add(list);
            }
            else
            {
                _context.Product.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}