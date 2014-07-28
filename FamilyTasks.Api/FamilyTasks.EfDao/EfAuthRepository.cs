using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Dao.Repositories;
using FamilyTasks.Dto.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.EfDao
{
    public class EfAuthRepository : IAuthRepository, IDisposable
    {
        private readonly EfContext _context;
        public EfAuthRepository()
        {
            _context = new EfContext();
        }

        public async Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
        {
            var user = _context.Set<User>().Create();
            user.Email = createUserDto.Email;
            user.FirstName = createUserDto.DisplayName;
            user.Password = createUserDto.Password;
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return new IdentityResult();
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
           var user = _context.Set<User>().FirstOrDefault(x => x.FirstName == userName);

           if (user != null)
           {
               return new IdentityUser(userName);
           }
           return null;
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
