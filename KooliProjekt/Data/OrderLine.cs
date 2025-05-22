using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    public class OrderLine
    {
        [ExcludeFromCodeCoverage]
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }

        // tellimus: tooted
        public OrderLine User { get; set; }
        public int OrderLineId { get; set; }

        //toode
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
