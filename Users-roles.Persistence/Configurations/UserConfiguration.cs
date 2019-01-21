using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users_roles.Domain.Entities;

namespace Users_roles.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100);
            builder.Property(e => e.Password).HasMaxLength(300).IsRequired();

            builder.OwnsOne(e => e.Email);
            builder.OwnsOne(e => e.Name);
        }
    }
}
