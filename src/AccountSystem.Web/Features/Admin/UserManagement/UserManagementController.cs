using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AccountSystem.Services.Identity;
using AccountSystem.Web.Core.Services;
using AccountSystem.Web.Features.Admin.UserManagement.Models;
using AccountSystem.Web.Features.Admin.Users.Models;
using AccountSystem.Web.Features.Shared;

namespace AccountSystem.Web.Features.Admin.UserManagement
{
    [Authorize, Route("~/admin/users")]
    public class UserManagementController : AppBaseController
    {
        private readonly UserService _userService;

        public UserManagementController(IAppServices appServices, UserManager<Entities.User> userManager, RoleManager<IdentityRole<int>> roleManager) : base(appServices)
        {
            _userService = new UserService(userManager, roleManager, appServices.DataContextFactory);
        }

        [Route("")]
        public IActionResult Index(string search = "", string role = "")
        {
            var viewModel = new IndexViewModel
            {
                Search = search,
                Role = role
            };

            return View(viewModel);
        }

        [HttpPost("json")]
        public JsonResult GetUsers([DataSourceRequest] DataSourceRequest request, string search = "", string role = "")
        {
            var results = _userService.GetUsers(search, role, i => i.ToDataSourceResult(request));
            return KendoJson(results);
        }

        [Route("{userId}/edit")]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            var model = await new EditUserViewModel(user).Hydrate(_userService);

            return View(model);
        }

        [HttpPost("{userId}/edit"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, EditUserViewModel model)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = model.User.FirstName;
            user.LastName = model.User.LastName;
            user.Email = model.User.Email;

            await _userService.SaveUser(user);
            await _userService.SetRoles(user, model.UserRoles);

            SetStatusMessage("User successfully updated.");

            return RedirectToAction(nameof(Index));
        }
    }
}
