using System;
using System.Collections.Generic;
using System.Text;
using UsersRoles.Application.Users.Models;

namespace UsersRoles.Application.Users.Queries.GetUsersList
{
    public class UsersListViewModel
    {
        public UsersListViewModel()
        {
            Users = new List<UserLookupModel>();
            AllRoles = new List<RoleLookupModel>();
        }

        public IEnumerable<UserLookupModel> Users { get; set; }

        public IEnumerable<RoleLookupModel> AllRoles { get; set; }
    }
}
