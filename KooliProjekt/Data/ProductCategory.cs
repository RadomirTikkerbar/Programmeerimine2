using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    public class ProductCategory
    {
        [ExcludeFromCodeCoverage]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
