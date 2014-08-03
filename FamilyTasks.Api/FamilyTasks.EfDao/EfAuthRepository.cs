using System;
using System.Linq;
using System.Threading.Tasks;
using FamilyTasks.Dao.Repositories;
using FamilyTasks.Dto.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.EfDao
{
    public class EfAuthRepository : GenericRepository<User>, IAuthRepository 
    {
        public EfAuthRepository(EfContext context)
            : base(context)
        {

        }

        public async Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
        {
            var user = Db.Set<User>().Create();
            user.Phone = createUserDto.Phone;
            user.Password = createUserDto.Password;
            user.Profile = Db.Set<Profile>().Create();
            user.Profile.Id = user.Id;
            Db.Set<User>().Add(user);
            Db.SaveChanges();
            return IdentityResult.Success;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = Db.Set<User>().FirstOrDefault(x => x.Phone == userName);

           if (user != null)
           {
               return new IdentityUser(userName);
           }

           return null;
        }
    }
}
