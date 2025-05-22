using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IProductCategoryService
    {
        Task<PagedResult<ProductCategory>> List(int page, int pageSize, ProductCategorySearch search = null);
        Task<ProductCategory> Get(int id);
        Task Save(ProductCategory category);
        Task Delete(int id);
    }
}