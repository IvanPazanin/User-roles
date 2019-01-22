using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using UsersRoles.Domain.Entities;
using UsersRoles.Domain.Enumerations;
using UsersRoles.Domain.ValueObjects;

namespace UsersRoles.Persistence
{
    public class UsersRolesInitializer
    {
        private readonly IDictionary<string, Role> Roles = new Dictionary<string, Role>();

        private readonly IDictionary<string, User> Users = new Dictionary<string, User>();

        public static void Initialize(UsersRolesDbContext context)
        {
            var initializer = new UsersRolesInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(UsersRolesDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Roles.Any())
                return;

            SeedRoles(context);
            SeedUsers(context);
            SeedUserRoles(context);
        }

        private void SeedUserRoles(UsersRolesDbContext context)
        {
            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(0),
                    RoleId = Roles.Keys.ElementAt(0)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(0),
                    RoleId = Roles.Keys.ElementAt(1)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(1),
                    RoleId = Roles.Keys.ElementAt(2)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(1),
                    RoleId = Roles.Keys.ElementAt(1)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(2),
                    RoleId = Roles.Keys.ElementAt(0)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(2),
                    RoleId = Roles.Keys.ElementAt(1)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(2),
                    RoleId = Roles.Keys.ElementAt(2)
                },
                new UserRole
                {
                    UserId = Users.Keys.ElementAt(3),
                    RoleId = Roles.Keys.ElementAt(1)
                },
            };

            context.UserRoles.AddRange(userRoles);

            context.SaveChanges();
        }

        private void SeedUsers(UsersRolesDbContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    FullName = (FullName)"Ivan Pažanin",
                    UserAvatarRelativePath = "avatar-placeholder.png",
                    MyEmail = (MyEmail)"ipazan00@fesb.hr",
                },
                new User
                {
                    FullName = (FullName)"Lukas Lawrence",
                    UserAvatarRelativePath = "avatar-placeholder.png",
                    MyEmail = (MyEmail)"lukaslw@gmail.com",
                },
                new User
                {
                    FullName = (FullName)"Pedro Pascal Maxwell",
                    UserAvatarRelativePath = "avatar-placeholder.png",
                    MyEmail = (MyEmail)"ppmaxwell@gmail.com",
                },
                new User
                {
                    FullName = (FullName)"Nicolette Ellis",
                    UserAvatarRelativePath = "avatar-placeholder.png",
                    MyEmail = (MyEmail)"nellis@gmail.com",
                },
            };

            foreach (var user in users)
                Users.Add(user.Id, user);

            context.AddRange(users);

            context.SaveChanges();
        }

        public void SeedRoles(UsersRolesDbContext context)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    RoleName = RoleName.Admin
                },
                new Role
                {
                    RoleName = RoleName.User
                },
                new Role
                {
                    RoleName = RoleName.Guest
                },
                new Role
                {
                    RoleName = RoleName.Test
                },
            };

            foreach (var role in roles)
                Roles.Add(role.Id, role);

            context.Roles.AddRange(roles);

            context.SaveChanges();
        }
    }
}
