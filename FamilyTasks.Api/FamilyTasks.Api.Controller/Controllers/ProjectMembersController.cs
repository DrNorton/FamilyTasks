using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Api.Controller.Entities;
using FamilyTasks.Dto.Projects;
using FamilyTasks.Dto.Users;

namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/ProjectMembers")]
    public class ProjectMembersController : CustomApiController
    {
        [Authorize]
        [Route("Members")]
        [HttpGet]
        [QueryJsonFilter(typeof(IdentityModel), "param")]
        public IHttpActionResult Members(IdentityModel param)
        {
            return SuccessApiResult(new List<ProjectMemberDto>()
            {
                new ProjectMemberDto(){ ProjectId = param.Identity,User = new UserDto()
                {
                    AvatarUrl = @"http://cs319429.vk.me/v319429704/4a5e/gCeesEuW5ZA.jpg",
                    DisplayName = "Дима Иванов",
                    Email = "dimaivanov1@mail.ru",
                    FirstName = "Дмитриий",
                    LastName = "Иванов", 
                    Phone = "+79166728879"
                }},
                 new ProjectMemberDto(){ ProjectId = param.Identity,User = new UserDto()
                {
                    AvatarUrl = @"http://risovach.ru/upload/2013/01/mem/krasavchik_9740575_orig_.jpg",
                    DisplayName = "Александр Беляев",
                    Email = "belyaev@mail.ru",
                    FirstName = "Александр",
                    LastName = "Беляев", 
                    Phone = "+79164728273"
                }},
                  new ProjectMemberDto(){ ProjectId = param.Identity,User = new UserDto()
                {
                    AvatarUrl = @"http://cs418626.vk.me/v418626886/2f77/lOPO7S6rENc.jpg",
                    DisplayName = "Александр Друзь",
                    Email = "dryaze@mail.ru",
                    FirstName = "Александр",
                    LastName = "Друзь", 
                    Phone = "+79155879654"
                }},
            });
        }
    }
}
