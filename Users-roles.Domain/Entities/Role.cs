using System;
using System.Collections.Generic;
using System.Text;
using Users_roles.Domain.Enumerations;

namespace Users_roles.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<UserRole>();    
        }

        public string Id { get; set; }

        public RoleType RoleType { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}
