using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Users_roles.Application.Users.Commands.EditUserRoles;

namespace UsersRoles.WebUI.Controllers
{
    [Route("api/users/[action]")]
    public class ApiUsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> EditUserRoles([FromBody]EditUserRolesCommand command)
        {
            return Json(await Mediator.Send(command));
        }
    }
}
