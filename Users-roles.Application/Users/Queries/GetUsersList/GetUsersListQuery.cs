using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace UsersRoles.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<UsersListViewModel>
    {
        public int Count { get; set; }
    }
}
