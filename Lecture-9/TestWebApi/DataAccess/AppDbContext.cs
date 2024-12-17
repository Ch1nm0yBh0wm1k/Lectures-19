using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options) { }
        public DbSet<Product> product { get; set; }
    }
}
