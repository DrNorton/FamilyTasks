using System;
using System.Threading.Tasks;
using FamilyTasks.Dto.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.Dao.Repositories
{
    public interface IAuthRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(CreateUserDto createUserDto);

        Task<IdentityUser> FindUser(string userName, string password);
    }
}
