using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Core.Models;
using FamilyTasks.Mobile.Core.ViewModels.Base;
using Task = FamilyTasks.Mobile.Core.Models.Task;

namespace FamilyTasks.Mobile.Core.ViewModels.Projects
{
    public class ProjectViewModel:LoadingMvxViewModel
    {
        private readonly IApiManager _apiManager;
        private Project _project;
        private ObservableCollection<User> _users;
        private ObservableCollection<Models.Task> _tasks;

        public ProjectViewModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
            _users = new ObservableCollection<User>();
            _tasks = new ObservableCollection<Task>();
        }

        public async void Init(long projectId)
        {
            var projectResponse = (await _apiManager.GetProjectById(projectId));
            Project = new Project(){Description = projectResponse.Result.Description,Id=projectResponse.Result.Id,Name = projectResponse.Result.Name,ProjectUrl = projectResponse.Result.ProjectUrl};
            //Участники
            await GetProjectMembers(projectId);
            var taskResponse=await _apiManager.GetTaskByProjectId(projectId);
            foreach (var taskResp in taskResponse.Result)
            {
                Tasks.Add(new Task(){CreateDateTime = taskResp.CreateDateTime,
                    Description = taskResp.Description,
                    EmployeeUserId = taskResp.EmployeeUserId,
                    Id=taskResp.Id,
                    Name = taskResp.Name,
                    ProjectId = taskResp.ProjectId});
            }
        }

        private async System.Threading.Tasks.Task GetProjectMembers(long projectId)
        {
            var membersResponse = (await _apiManager.GetProjectMembersByProjectId(projectId)).Result;

            foreach (var memberResponse in membersResponse)
            {
                Users.Add(new User()
                {
                    AvatarUrl = memberResponse.User.AvatarUrl,
                    DisplayName = memberResponse.User.DisplayName,
                    Email = memberResponse.User.Email,
                    Phone = memberResponse.User.Phone
                });
            }
        }

        public Models.Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                base.RaisePropertyChanged(()=>Project);
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                base.RaisePropertyChanged(()=>Users);
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                base.RaisePropertyChanged(()=>Tasks);
            }
        }
    }
}
