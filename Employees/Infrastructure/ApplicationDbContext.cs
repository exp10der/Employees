namespace Employees.Infrastructure
{
    using System.Data.Entity;
    using Domain;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}