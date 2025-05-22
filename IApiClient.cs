using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace KooliProjekt.BlazorApp
{
    public interface IApiClient
    {
        Task<Result<Order>> Get(int id);
        Task<Result<List<Order>>> List();
        Task<Result> Save(Order list);
        Task Delete(int id);
    }

    public class Order
    {
        [ExcludeFromCodeCoverage]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }

        // mis tooted tellib klient
        public IList<Order> Lines { get; set; }

        public Order()
        {
            Lines = new List<Order>();
        }
    }
}