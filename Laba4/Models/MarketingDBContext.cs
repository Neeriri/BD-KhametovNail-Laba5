using System.Data.Entity;
using Laba4.Models;

namespace Laba4.Models
{
    public class MarketingDBContext : DbContext
    {
        public MarketingDBContext()
            : base("name=MarketingDBConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure table mappings if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
