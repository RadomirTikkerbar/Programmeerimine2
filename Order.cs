using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.BlazorApp.Api
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        public static implicit operator List<object>(Order? v)
        {
            throw new NotImplementedException();
        }
    }
}
