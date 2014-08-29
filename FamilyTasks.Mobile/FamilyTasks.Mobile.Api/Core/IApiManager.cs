using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Api.Core
{
    public interface IApiManager
    {
        Task<Response<AutorizationResponse>> Autorizate(AutorizationRequest autorizationRequest);
        Task<Response<string>> Register(RegistrationRequest autorizationRequest);
        Task<Response<List<ProjectResponse>>> GetMyProjects();
        Task<Response<List<TaskResponse>>> GetTaskByProjectId(long projectId);
        bool IsAutorizated { get; }
        Task<Response<List<ProjectResponse>>> GetMyInvintedProjects();
        Task<Response<ProjectResponse>> GetProjectById(long projectId);
        Task<Response<string>> DeleteMyProject(long projectId);
        Task<Response<TaskResponse>> GetTaskById(long taskId);
        Task<Response<List<ProjectMemberResponse>>> GetProjectMembersByProjectId(long projectId);
    }
}