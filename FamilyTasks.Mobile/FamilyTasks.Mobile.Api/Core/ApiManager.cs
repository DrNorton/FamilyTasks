using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Request.Project;
using FamilyTasks.Mobile.Api.Request.ProjectMember;
using FamilyTasks.Mobile.Api.Request.Task;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Core
{
    public class ApiManager : IApiManager
    {
        private readonly IRequestExecuterService _requestExecuterService;

        public bool IsAutorizated
        {
            get { return _requestExecuterService.IsAutorizated; }
        }

        public ApiManager(IRequestExecuterService requestExecuterService)
        {
            _requestExecuterService = requestExecuterService;
        }
        #region Auth
        public async Task<Response<AutorizationResponse>> Autorizate(AutorizationRequest autorizationRequest)
        {
            return await _requestExecuterService.Autorization(autorizationRequest);
        }

        public async Task<Response<string>> Register(RegistrationRequest autorizationRequest)
        {
            return await _requestExecuterService.ExecuteRequest<string>(autorizationRequest);
        }

        #endregion

        #region Projects
        public async Task<Response<List<ProjectResponse>>> GetMyProjects()
        {
            return await _requestExecuterService.ExecuteRequest<List<ProjectResponse>>(new GetProjectsRequest());
        }

        public async Task<Response<List<ProjectResponse>>> GetMyInvintedProjects()
        {
            return await _requestExecuterService.ExecuteRequest<List<ProjectResponse>>(new GetInvitedProjectsRequest());
        }

        public async Task<Response<ProjectResponse>> GetProjectById(long projectId)
        {
            return await _requestExecuterService.ExecuteRequest<ProjectResponse>(new GetProjectRequest(){Identity = 3});
        }

        public async Task<Response<string>> DeleteMyProject(long projectId)
        {
            return await _requestExecuterService.ExecuteRequest<string>(new DeleteMyProject() { Identity = 3 });
        }

        #endregion

        #region Tasks
        public async Task<Response<List<TaskResponse>>> GetTaskByProjectId(long projectId)
        {
            return await _requestExecuterService.ExecuteRequest<List<TaskResponse>>(new GetTasksByProjectIdRequest(){Identity = projectId});
        }

        public async Task<Response<TaskResponse>> GetTaskById(long taskId)
        {
            return await _requestExecuterService.ExecuteRequest<TaskResponse>(new GetTaskByIdRequest() { Identity = taskId });
        }

        #endregion

        #region Project Members
        public async Task<Response<List<ProjectMemberResponse>>> GetProjectMembersByProjectId(long projectId)
        {
            return await _requestExecuterService.ExecuteRequest<List<ProjectMemberResponse>>(new GetProjectMembers(){Identity = projectId});
        }
        #endregion

    }
}
