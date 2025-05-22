using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IOrderLineService
    {
        Task<PagedResult<OrderLine>> List(int page, int pageSize, OrderLineSearch search);
        Task<OrderLine> Get(int id);
        Task Save(OrderLine list);
        Task Delete(int id);
    }
}