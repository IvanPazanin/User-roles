using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UsersRoles.Domain.Entities;

namespace UsersRoles.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId });
            builder.Property(e => e.UserId).HasMaxLength(100);
            builder.Property(e => e.RoleId).HasMaxLength(100);
        }
    }
}
