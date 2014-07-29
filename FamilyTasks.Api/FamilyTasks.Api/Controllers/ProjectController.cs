using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using FamilyTasks.Api.ApiResults;
using FamilyTasks.Dto.Projects;
using FamilyTasks.Dto.Tasks;


namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : CustomApiController
    {
        [Authorize]
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

        [Authorize]
        public IHttpActionResult Tasks(long projectId)
        {
            return SuccessApiResult(new List<TasksListItemDto> {new TasksListItemDto {Id = 1, Name = "asdsad"}});
        }

    }
}