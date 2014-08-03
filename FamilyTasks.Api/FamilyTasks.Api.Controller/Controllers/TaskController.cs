using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyTasks.Api.Controller.ApiResults;
using FamilyTasks.Api.Controller.Entities;
using FamilyTasks.Dto.Tasks;

namespace FamilyTasks.Api.Controller.Controllers
{
    [RoutePrefix("api/Task")]
    public class TaskController : CustomApiController
    {

        [Authorize]
        [Route("TasksByProjectId")]
        [HttpGet]
        [QueryJsonFilter(typeof(IdentityModel),"param")]
        public IHttpActionResult TasksByProjectId(IdentityModel param)
        {
            return SuccessApiResult(new List<TasksListItemDto>()
            {
                new TasksListItemDto()
                {
                    Id=1,
                    Name = "Почистить картошку",
                    Description = "Взять ведро, нож и наклепать картофана для лазаньи",
                    ProjectId = param.Identity,
                    EmployeeUserId = 1
                },
                new TasksListItemDto()
                {
                    Id = 2,
                    Name = "Почистить моркволь",
                    Description = "Взять ведро, нож и наклепать морковль для лазаньи",
                    ProjectId = param.Identity,
                    EmployeeUserId = null
                }
            });
        }

        [Authorize]
        [Route("Task")]
        [HttpGet]
        [QueryJsonFilter(typeof(IdentityModel), "param")]
        public IHttpActionResult Task(IdentityModel param)
          {
              return SuccessApiResult(new TasksListItemDto()
              {
                  Id = param.Identity,
                  Name = "Почистить картошку",
                  Description = "Взять ведро, нож и наклепать картофана для лазаньи",
                  ProjectId = 1,
                  EmployeeUserId = 1
              });

          }
    }
}
