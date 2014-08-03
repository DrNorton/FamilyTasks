using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Api.Controller.Entities;
using FamilyTasks.Dto.Friends;


namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/Friend")]
    public class FriendController : CustomApiController
    {
        [Authorize]
        [Route("Friends")]
        [HttpGet]
        public IHttpActionResult Friends()
        {
            return SuccessApiResult(new List<FriendListItemDto>()
            {
                new FriendListItemDto(){UserId = 1,AvatarUrl =@"http://picsdesktop.net/summer/1920x1440_PicsDesktop.net_5.jpg.htm",DisplayName = "Вован",Telephone = "+79166728879"},
                new FriendListItemDto(){UserId = 2,AvatarUrl =@"http://picsdesktop.net/summer/1920x1440_PicsDesktop.net_5.jpg.htm",DisplayName = "Димон",Telephone = "+79166728879"}
            });
        }

        [Authorize]
        [Route("AddFriend")]
        [HttpPost]
        [QueryJsonFilter(typeof(IdentityModel), "param")]
        public IHttpActionResult AddFriend(IdentityModel param)
        {
            return EmptyApiResult();
        }

        [Authorize]
        [Route("DeleteFriend")]
        [HttpPost]
        [QueryJsonFilter(typeof(IdentityModel), "param")]
        public IHttpActionResult DeleteFriend(IdentityModel param)
        {
            return EmptyApiResult();
        }
    }
}
