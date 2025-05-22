using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IProductService
    {
        Task<PagedResult<Product>> List(int page, int pageSize, ProductSearch search = null);
        Task<Product> Get(int id);
        Task Save(Product list);
        Task Delete(int id);
    }
}