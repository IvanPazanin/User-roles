using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersRoles.Persistence;
using UsersRoles.Application.Users.Models;

namespace UsersRoles.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
    {
        private readonly UsersRolesDbContext _context;

        public GetUsersListQueryHandler(UsersRolesDbContext context)
        {
            _context = context;
        }

        public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {            
            var users = await _context.Users
                .Take(request.Count)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .OrderBy(u => u.FullName.FirstName)
                .ToListAsync(cancellationToken);

            return new UsersListViewModel
            {
                Users = users.AsQueryable().Select(UserLookupModel.Projection).ToList(),
                AllRoles = await _context.Roles
                    .Select(RoleLookupModel.Projection)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
