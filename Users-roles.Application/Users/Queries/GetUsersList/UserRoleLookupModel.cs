using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using UsersRoles.Domain.Entities;

namespace UsersRoles.Application.Users.Queries.GetUsersList
{
    public class UserRoleLookupModel
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserId { get; set; }

        public static Expression<Func<UserRole, UserRoleLookupModel>> Projection
        {
            get
            {
                return ur => new UserRoleLookupModel
                {
                    RoleId = ur.RoleId,
                    UserId = ur.UserId,
                    RoleName = ur.Role.RoleName.ToString()
                };
            }
        }
    }
}
