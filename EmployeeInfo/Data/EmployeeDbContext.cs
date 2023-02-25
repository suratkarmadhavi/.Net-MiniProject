using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> opt)
            : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
        }

        public DbSet<Employee> tEmployee { get; set; }

    }
}
