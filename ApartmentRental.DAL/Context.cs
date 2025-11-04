using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Database.EnsureCreated();

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=ApartmentRental;Trusted_Connection=True;TrustServerCertificate=True;");

            base.OnConfiguring(builder);
        }
    }
}
