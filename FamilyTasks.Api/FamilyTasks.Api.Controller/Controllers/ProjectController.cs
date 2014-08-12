using System.Collections.Generic;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Api.Controller.Entities;
using FamilyTasks.Dto.Projects;
using FamilyTasks.Dto.Tasks;
using Newtonsoft.Json.Linq;

namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : CustomApiController
    {

        [Authorize]
        [Route("Projects")]
        [HttpGet]
        public IHttpActionResult Projects()
        {
            return SuccessApiResult(new List<ProjectsListItemDto>
            {
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 1,
                    Name = "First Project",
                    ProjectUrl=@"http://l-userpic.livejournal.com/122437763/25587933"
                },
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 2,
                    Name = "Second Project",
                    ProjectUrl=@"http://l-userpic.livejournal.com/122437763/25587933"
                },
            });
        }

        [Authorize]
        [Route("Project")]
        [HttpGet]
        [QueryJsonFilter(typeof(IdentityModel), "param")]
        public IHttpActionResult Project(IdentityModel param)
        {
            return SuccessApiResult(new ProjectsListItemDto(){
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = param.Identity,
                    Name = "First Project",
                    ProjectUrl=@"http://l-userpic.livejournal.com/122437763/25587933"
                });
        }

        [Authorize]
        [Route("InvitedProjects")]
        [HttpGet]
        public IHttpActionResult InvitedProjects()
        {
            return SuccessApiResult(new List<ProjectsListItemDto>
            {
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 1,
                    Name = "First Project",
                    ProjectUrl=@"http://l-userpic.livejournal.com/122437763/25587933"
                },
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 2,
                    Name = "Second Project",
                    ProjectUrl=@"http://l-userpic.livejournal.com/122437763/25587933"
                },
            });
        }

        [Authorize]
        [Route("DeleteMyProject")]
        [HttpPost]
        public IHttpActionResult DeleteMyProject(IdentityModel param)
        {
            return EmptyApiResult();
        }

    }
}