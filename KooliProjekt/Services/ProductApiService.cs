using KooliProjekt.Controllers;
using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    //public class ProductApiService : IProductApiService
    //{
    //    private readonly ApplicationDbContext _context;

    //    public ProductApiService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task Delete(int id)
    //    {
    //        var productApi = await _context.ProductApi.FindAsync(id);
    //        if (productApi != null)
    //        {
    //            _context.ProductApi.Remove(productApi);
    //            await _context.SaveChangesAsync();
    //        }
    //    }
    //    public async Task<ProductApi> Get(int id)
    //    {
    //        return await _context.ProductApi.FindAsync(id);
    //    }
    //    public async Task<PagedResult<ProductApi>> List(int page, int pageSize, ProductApiApiSearch search = null)
    //    {
    //        var query = _context.ProductApi.AsQueryable();

    //        search = search ?? new ProductApiSearch();

    //        if (!string.IsNullOrWhiteSpace(search.Keyword))
    //        {
    //            query = query.Where(list => list.Name.Contains(search.Keyword));
    //        }

    //        return await query
    //            .OrderBy(list => list.Name)
    //            .GetPagedAsync(page, pageSize);
    //    }
    //    public async Task Save(ProductApi list)
    //    {
    //        if (list.Id == 0)
    //        {
    //            _context.ProductApi.Add(list);
    //        }
    //        else
    //        {
    //            _context.ProductApi.Update(list);
    //        }

    //        await _context.SaveChangesAsync();
    //    }

    //    public Task Save(ProductApi list)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<ProductApi> IProductApiService.Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<PagedResult<ProductApi>> IProductApiService.List(int page, int pageSize, ProductApiSearch search)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    internal class ProductApiSearch : ProductApiApiSearch
    {
    }

    public class ProductApiApiSearch
    {
        internal object Keyword;
    }
}