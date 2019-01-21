using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersRoles.Application.Users.Queries.GetUsersList;

namespace UsersRoles.WebUI.Controllers
{
    public class UsersController : BaseController 
    {
        public async Task<IActionResult> UsersList(int count = 10)
        {
            var users = await Mediator.Send(new GetUsersListQuery {Count = count});
            return View(users);
        }
    }
}
