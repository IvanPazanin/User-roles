using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Users_roles.Application.Users.Commands.EditUserRoles
{
    public class EditUserRolesCommand : IRequest
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public bool HasRole { get; set; }
    }
}
