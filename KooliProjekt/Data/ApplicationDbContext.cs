using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KooliProjekt.Data.Order> Order { get; set; } = default!;
        public DbSet<KooliProjekt.Data.OrderLine> OrderLine { get; set; } = default!;
        public DbSet<KooliProjekt.Data.Product> Product { get; set; } = default!;
        public DbSet<KooliProjekt.Data.ProductCategory> ProductCategory { get; set; } = default!;


    }
}