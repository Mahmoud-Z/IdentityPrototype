using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityTest.Models
{
    public class SeedingDbTestContext : IdentityDbContext<Users>
    {
        public SeedingDbTestContext(DbContextOptions<SeedingDbTestContext> options) : base(options)
        {
        }
        public SeedingDbTestContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentLine> DocumentLines { get; set; }
        public DbSet<Taxes> Taxes { get; set; }
        public DbSet<test> test { get; set; }
        public DbSet<test2> test2 { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
