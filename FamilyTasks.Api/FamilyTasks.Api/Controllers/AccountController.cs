using System.Threading.Tasks;
using System.Web.Http;
using FamilyTasks.Api.ApiResults;
using FamilyTasks.Api.Entities;
using FamilyTasks.Dto.Users;
using FamilyTasks.EfDao;
using Microsoft.AspNet.Identity;

namespace FamilyTasks.Api.Controllers
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : CustomApiController
    {
        private EfAuthRepository _repo = null;

        public AccountController()
        {
            _repo = new EfAuthRepository();
        }

        // POST api/Account/Register
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(new CreateUserDto(userModel.Email, userModel.Email, string.Empty, userModel.Password));

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
                _repo.Dispose();
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