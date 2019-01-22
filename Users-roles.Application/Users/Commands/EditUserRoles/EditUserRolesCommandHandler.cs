using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersRoles.Domain.Entities;
using UsersRoles.Persistence;

namespace Users_roles.Application.Users.Commands.EditUserRoles
{
    public class EditUserRolesCommandHandler : IRequestHandler<EditUserRolesCommand>
    {
        private readonly UsersRolesDbContext _context;

        public EditUserRolesCommandHandler(UsersRolesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var user = await _context.Users.Include(u => u.UserRoles).SingleOrDefaultAsync(u => u.Id == request.UserId);

            if(user == null)
                throw new Exception($"User with id:{request.UserId} was not found");

            if (!roles.Any(r => r.Id == request.RoleId))
                throw new Exception($"There is no role with id:{request.RoleId}");

            if (request.HasRole)
                user.UserRoles.Remove(user.UserRoles.SingleOrDefault(ur => ur.RoleId == request.RoleId));

            else
                user.UserRoles.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = request.RoleId
                });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
