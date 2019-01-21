using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersRoles.Domain.Entities;
using UsersRoles.Domain.Enumerations;

namespace UsersRoles.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(100);
            builder.Property(e => e.RoleName).HasConversion<int>();
        }
    }
}
