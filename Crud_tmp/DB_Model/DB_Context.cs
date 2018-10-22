using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture
{
    public class DB_Context: DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> contextOptions) :base(contextOptions) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
