using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
