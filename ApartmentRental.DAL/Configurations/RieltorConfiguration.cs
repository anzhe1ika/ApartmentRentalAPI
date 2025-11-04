using ApartmentRental.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApartmentRental.DAL.Configurations
{
    public class RieltorConfiguration : IEntityTypeConfiguration<Rieltor>
    {
        public void Configure(EntityTypeBuilder<Rieltor> builder)
        {
            builder.ToTable("Rieltor").HasKey(x => x.ID);
        }
    }
}
