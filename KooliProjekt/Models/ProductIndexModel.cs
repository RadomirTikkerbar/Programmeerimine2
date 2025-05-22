using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Models
{
    [ExcludeFromCodeCoverage]

    public class ProductIndexModel
    {
        public ProductSearch Search { get; set; }
        public PagedResult<Product> Data { get; set; }
    }
}