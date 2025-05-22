using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    public class Order
    {
        [ExcludeFromCodeCoverage]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //seob kasutaja tellimusega
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        // mis tooted tellib klient
        public IList<Order> Lines { get; set; }

        public Order()
        {
            Lines = new List<Order>();
        }
    }
}
