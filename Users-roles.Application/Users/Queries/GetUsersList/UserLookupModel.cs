using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UsersRoles.Domain.Entities;

namespace UsersRoles.Application.Users.Queries.GetUsersList
{
    public class UserLookupModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string UserAvatarRelativePath { get; set; }

        public IEnumerable<UserRoleLookupModel> Roles { get; set; }

        public static Expression<Func<User, UserLookupModel>> Projection
        {
            get
            {
                return u => new UserLookupModel
                {
                    Id = u.Id,
                    Email = u.MyEmail,
                    Name = u.FullName,
                    UserAvatarRelativePath = u.UserAvatarRelativePath,
                    Roles = u.UserRoles.Select(ur => new UserRoleLookupModel
                    {
                        RoleId = ur.RoleId,
                        UserId = ur.UserId,
                        RoleName = ur.Role.RoleName.ToString()
                    })
                };
            }
        }
    }
}
