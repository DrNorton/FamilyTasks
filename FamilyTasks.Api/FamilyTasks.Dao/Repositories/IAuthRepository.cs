using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Dto.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.Dao.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(CreateUserDto createUserDto);

        Task<IdentityUser> FindUser(string userName, string password);
    }
}
