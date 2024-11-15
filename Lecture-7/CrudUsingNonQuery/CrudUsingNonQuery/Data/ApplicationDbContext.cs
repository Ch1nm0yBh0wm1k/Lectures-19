using CrudUsingNonQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingNonQuery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Products { get; set; }

    }
}
