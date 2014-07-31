using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using FamilyTasks.Api.ApiResults;
using FamilyTasks.Dto.Projects;
using FamilyTasks.Dto.Tasks;
using Newtonsoft.Json.Linq;


namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : CustomApiController
    {

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("List")]
        public IHttpActionResult List()
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

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("Tasks")]
        public IHttpActionResult Tasks([FromBody]JToken projectId)
        {
            return SuccessApiResult(new List<TasksListItemDto> {new TasksListItemDto {Id = 1, Name = "asdsad"}});
        }

    }
}