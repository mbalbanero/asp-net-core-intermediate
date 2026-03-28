using CRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Data
{
    public class CRMDbContext : DbContext
    {
        //Constructor
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {
        }

        //Define Database Tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
