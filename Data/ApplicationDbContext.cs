using Microsoft.EntityFrameworkCore;
using NdegwaInsuranceApi.Models;

namespace NdegwaInsuranceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>()
                .ToTable("tb_insurance_policies");

            modelBuilder.Entity<Admin>()
                .ToTable("tb_admin");
        }
    }
}