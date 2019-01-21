using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users_roles.Domain.Entities;
using Users_roles.Domain.Enumerations;

namespace Users_roles.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100);
            builder.Property(e => e.RoleType).HasConversion<int>();
        }
    }
}
