using System.Collections.Generic;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Dto.Projects;
using FamilyTasks.Dto.Tasks;
using Newtonsoft.Json.Linq;

namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : CustomApiController
    {

        [Authorize]
        [Route("GetMyProjects")]
        public IHttpActionResult GetMyProjects()
        {
            return SuccessApiResult(new List<ProjectsListItemDto>
            {
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 1,
                    Name = "First Project"
                },
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 2,
                    Name = "Second Project"
                },
            });
        }

        [Authorize]
        [Route("GetMyProjectById")]
        public IHttpActionResult GetMyProjectById(long projectId)
        {
            return SuccessApiResult(new ProjectsListItemDto(){
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 1,
                    Name = "First Project"
                });
        }


        [Authorize]
        [Route("GetMyInvitedProjects")]
        public IHttpActionResult GetMyInvitedProjects()
        {
            return SuccessApiResult(new List<ProjectsListItemDto>
            {
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 1,
                    Name = "First Project"
                },
                new ProjectsListItemDto
                {
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make",
                    Id = 2,
                    Name = "Second Project"
                },
            });
        }

        [Authorize]
        [Route("DeleteMyProjectById")]
        public IHttpActionResult DeleteMyProjectById(long projectId)
        {
            return EmptyApiResult();
        }


        [Authorize]
        [Route("Tasks")]
        public IHttpActionResult Tasks([FromBody]JToken projectId)
        {
            return SuccessApiResult(new List<TasksListItemDto> {new TasksListItemDto {Id = 1, Name = "asdsad"}});
        }

    }
}