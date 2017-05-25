using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AccountSystem.Identity;
using Microsoft.AccountSystem.Mvc;
using Microsoft.AccountSystem.Mvc.Abstractions;
using Microsoft.AccountSystem.Mvc.ModelBinding;
using Microsoft.AccountSystem.Mvc.Rendering;
using Microsoft.AccountSystem.Mvc.ViewFeatures;
using OrangeJetpack.Services.Client.Models;
using AccountSystem.Web.Core.ErrorHandling.API;
using AccountSystem.Web.Core.Services;
using AccountSystem.Web.Features.Home;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountSystem.Web.Features.Shared
{
    [Route("api/[controller]")]
    public class ApiBaseController : AppBaseController
    {
        public ApiBaseController(IAppServices appServices) : base(appServices)
        {
        }

        [Route("model-state-error")]
        public IActionResult ModelStateError(ModelStateDictionary modelState)
        {
            var apiError = new ApiError
            {
                Type = ApiErrorType.ModelStateError,
                Message = "Model state is invalid.",
                Metadata = new
                {
                    fields = modelState.Keys.ToArray()
                }
            };
            return BadRequest(apiError);
        }
        [Route("invalid-argument-error")]
        public IActionResult InvalidArgumentError(string message)
        {
            var apiError = new ApiError
            {
                Type = ApiErrorType.ModelStateError,
                Message = message,
                Metadata = new
                {
                    message
                }
            };
            return BadRequest(apiError);
        }
        [Route("identity-result-error")]
        public IActionResult IdentityResultError(IdentityResult identityResult)
        {
            var apiError = new ApiError
            {
                Type = ApiErrorType.IdentityResultError,
                Message = "Identity result error.",
                Metadata = new
                {
                    errors = identityResult.Errors.ToArray()
                }
            };
            return BadRequest(apiError);
        }

        //public bool IsApiController()
        //{
        //    return true;
        //}
    }
}
