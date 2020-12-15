using AUBNB.Domain.Features.Hostings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUBNB.Infra.Data.Features.Hostings
{
    public class HostingEntityConfiguration : IEntityTypeConfiguration<Hosting>
    {
        public void Configure(EntityTypeBuilder<Hosting> builder)
        {
            builder.ToTable("Hostings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Note).IsRequired();
            builder.Property(x => x.Availability).IsRequired();
            builder.Property(x => x.HasDog).IsRequired();
            builder.Property(x => x.PlaceDescription).IsRequired();
            builder.Property(x => x.PatioSize).IsRequired();
            builder.Property(x => x.HousingType).IsRequired();
            builder.Property(x => x.AnimalSize).IsRequired();

            builder.Property(x => x.Street).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Number).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Neighborhood).IsRequired().HasMaxLength(250);
            builder.Property(x => x.City).IsRequired().HasMaxLength(250);
            builder.Property(x => x.State).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(250);
            builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AdditionalInfo).IsRequired().HasMaxLength(50);

            builder.HasOne(h => h.User).WithMany(u => u.Hostings).HasForeignKey(h => h.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
