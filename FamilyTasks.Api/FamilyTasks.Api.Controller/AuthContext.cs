using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyTasks.Api.Controller
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}