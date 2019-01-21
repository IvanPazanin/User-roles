using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UsersRoles.Domain.Entities;
using UsersRoles.Persistence.Extensions;

namespace UsersRoles.Persistence
{
    public class UsersRolesDbContext : DbContext
    {
        public UsersRolesDbContext(DbContextOptions<UsersRolesDbContext> options) : base(options)
        {            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
