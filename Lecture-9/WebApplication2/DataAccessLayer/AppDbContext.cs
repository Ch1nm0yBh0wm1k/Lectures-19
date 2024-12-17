using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options) { }
        public DbSet<Teacher> Teacher { get; set; }
    }
}
