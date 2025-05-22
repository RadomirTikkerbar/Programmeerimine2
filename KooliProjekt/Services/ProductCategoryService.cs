using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            await _context.ProductCategory
                .Where(list => list.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ProductCategory> Get(int id)
        {
            return await _context.ProductCategory.FindAsync(id);
        }

        public async Task<PagedResult<ProductCategory>> List(int page, int pageSize, ProductCategorySearch search = null)
        {
            var query = _context.ProductCategory.AsQueryable();

            search = search ?? new ProductCategorySearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Name.Contains(search.Keyword));
            }

            return await query
                .OrderBy(list => list.Name)
                .GetPagedAsync(page, pageSize);
        }

        public async Task Save(ProductCategory list)
        {
            if (list.Id == 0)
            {
                _context.ProductCategory.Add(list);
            }
            else
            {
                _context.ProductCategory.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
