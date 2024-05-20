using Microsoft.EntityFrameworkCore;
using OData.WebApi.Entities;

namespace OData.WebApi.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
