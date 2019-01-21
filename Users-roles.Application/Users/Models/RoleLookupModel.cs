using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using UsersRoles.Domain.Entities;

namespace UsersRoles.Application.Users.Models
{
    public class RoleLookupModel
    {
        public string Id { get; set; }

        public string RoleName { get; set; }

        public static Expression<Func<Role, RoleLookupModel>> Projection
        {
            get
            {
                return r => new RoleLookupModel
                {
                    Id = r.Id,
                    RoleName = r.RoleName.ToString()
                };
            }
        }
    }
}
