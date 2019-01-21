using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersRoles.Domain.Entities;

namespace UsersRoles.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100);
            builder.Property(e => e.Password).HasMaxLength(300).IsRequired();

            builder.OwnsOne(e => e.MyEmail);
            builder.OwnsOne(e => e.FullName);
        }
    }
}
