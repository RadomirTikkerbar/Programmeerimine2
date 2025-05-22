using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Models
{
    [ExcludeFromCodeCoverage]
    public class OrderLineIndexModel
    {

        public OrderLineSearch Search { get; set; }
        public PagedResult<OrderLine> Data { get; set; }
    }
}