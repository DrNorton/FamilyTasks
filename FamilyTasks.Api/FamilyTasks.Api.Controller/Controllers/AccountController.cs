using System;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Api.Controller.Entities;
using FamilyTasks.Dao.Repositories;
using FamilyTasks.Dto.Users;
using Microsoft.AspNet.Identity;

namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : CustomApiController
    {
        private readonly IAuthRepository _authRepository;

        public AccountController(IAuthRepository authRepository)
        {
            if (authRepository == null) throw new ArgumentNullException("authRepository");
            _authRepository = authRepository;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
         [HttpPost]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _authRepository.RegisterUser(new CreateUserDto(userModel.Phone, userModel.Password));

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return EmptyApiResult();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}