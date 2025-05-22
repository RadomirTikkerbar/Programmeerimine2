using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Order>> List(int page, int pageSize, OrderSearch search)
        {
            return await _context.Order.GetPagedAsync(page, 5);
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Order
                .AsNoTracking()
                .Include(List => List.Lines)
                .Where(list => list.Id == id)
                .FirstOrDefaultAsync();
        }



        public async Task Save(Order list)
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
