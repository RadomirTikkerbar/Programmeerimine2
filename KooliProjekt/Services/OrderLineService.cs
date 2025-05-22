using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly ApplicationDbContext _context;

        public OrderLineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<OrderLine>> List(int page, int pageSize, OrderLineSearch search)
        {
            return await _context.OrderLine.GetPagedAsync(page, 5);
        }

        public async Task<OrderLine> Get(int id)
        {
            return await _context.OrderLine
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(OrderLine list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoList = await _context.Order.FindAsync(id);
            if (todoList != null)
            {
                _context.Order.Remove(todoList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
