using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Models
{
    public class ProductCategoryIndexModel
    {
        public ProductCategorySearch Search { get; set; }
        public PagedResult<ProductCategory> Data { get; set; }
    }
}
