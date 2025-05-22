using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Models
{
    [ExcludeFromCodeCoverage]
    public class OrderIndexModel
    {
        public OrderSearch Search { get; set; }
        public PagedResult<Order> Data { get; set; }
    }
}