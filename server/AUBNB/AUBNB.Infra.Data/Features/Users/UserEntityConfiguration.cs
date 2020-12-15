using AUBNB.Domain.Features.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUBNB.Infra.Data.Features.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TelephoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Password).IsRequired();

            builder.HasMany(u => u.Hostings).WithOne(h => h.User).HasForeignKey(u => u.UserId);
        }
    }
}
