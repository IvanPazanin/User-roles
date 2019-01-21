using System;
using System.Collections.Generic;
using System.Text;
using UsersRoles.Domain.Enumerations;

namespace UsersRoles.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();    
        }

        public string Id { get; set; }

        public RoleName RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}
