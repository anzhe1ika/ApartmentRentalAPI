using ApartmentRental.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApartmentRental.DAL.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment").HasKey(x => x.ID);

            builder.HasOne(a => a.Owner)
                .WithMany(o => o.Apartments)
                .HasForeignKey(a => a.OwnerID)
                .HasPrincipalKey(o => o.ID);

            builder.HasOne(a => a.Rieltor)
                .WithMany(r => r.Apartments)
                .HasForeignKey(a => a.RieltorID)
                .HasPrincipalKey(r => r.ID);
        }
    }
}
