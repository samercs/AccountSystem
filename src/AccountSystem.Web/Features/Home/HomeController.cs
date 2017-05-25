using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccountSystem.Web.Core.Services;
using AccountSystem.Web.Features.Shared;

namespace AccountSystem.Web.Features.Home
{
    [Route("[controller]/[action]")]
    public class HomeController : AppBaseController
    {
        public HomeController(IAppServices appServices) : base(appServices)
        {
        }

        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("~/my-account")]
        public IActionResult MyAccount()
        {
            return View();
        }
    }
}
