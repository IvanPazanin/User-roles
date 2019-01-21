using System;
using System.Collections.Generic;
using System.Text;
using UsersRoles.Domain.ValueObjects;

namespace UsersRoles.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();
        }

        public string Id { get; set; }

        public MyEmail MyEmail { get; set; }

        public string Password { get; set; }

        public FullName FullName { get; set; }

        public string UserAvatarRelativePath { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}
