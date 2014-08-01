using System;
using System.Threading.Tasks;
using FamilyTasks.Api.Controller.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.Api.Controller
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _ctx;

        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}