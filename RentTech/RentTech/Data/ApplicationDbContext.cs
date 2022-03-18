using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentTech.Models.DomainModels;

namespace RentTech.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeds users and items
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        public DbSet<RentTech.Models.DomainModels.TechItem> TechItem { get; set; }
        public DbSet<RentTech.Models.DomainModels.Review> Review { get; set; }
        public DbSet<RentTech.Models.DomainModels.Tag> Tag { get; set; }
    }
}