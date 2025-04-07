using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

namespace CLDV6211POE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Venue> Venue {  get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>().ToTable("Venue");
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
