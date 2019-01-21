using System;
using System.Collections.Generic;
using System.Text;
using Users_roles.Domain.ValueObjects;

namespace Users_roles.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();
        }

        public string Id { get; set; }

        public Email Email { get; set; }

        public string Password { get; set; }

        public FullName Name { get; set; }

        public string UserAvatarRelativePath { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}
