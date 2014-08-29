using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Response;
using FamilyTasks.Mobile.Core.Models;
using FamilyTasks.Mobile.Core.ViewModels.Auth;
using FamilyTasks.Mobile.Core.ViewModels.Projects;
using FamilyTasks.Mobile.Core.ViewModels.Tasks;

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IApiManager _apiManager;
        private MvxCommand _navigateToMyProjectsCommand;
        private MvxCommand _navigateToMyProjectsCommandCommand;
        private ObservableCollection<Project> _myProjects;
        private MvxCommand _navigateToMyEventsCommand;
        private Project _selectedProject;

        public ICommand NavigateToMyEventsCommand
        {
            get
            {
                _navigateToMyEventsCommand = _navigateToMyEventsCommand ?? new MvxCommand(DoNavigateToMyEventsCommand);
                return _navigateToMyEventsCommand;
            }
        }

        public ICommand NavigateToMyProjectsCommandCommand
        {
            get
            {
                _navigateToMyProjectsCommandCommand = _navigateToMyProjectsCommandCommand ?? new MvxCommand(DoNavigateToMyProjectsCommandCommand);
                return _navigateToMyProjectsCommandCommand;
            }
        }

        private void DoNavigateToMyEventsCommand()
        {
            ShowViewModel<TaskListViewModel>();
        }

        private void DoNavigateToMyProjectsCommandCommand()
        {
            ShowViewModel<ProjectListViewModel>();
        }



        public ICommand NavigateToMyProjectCommand
        {
            get
            {
                _navigateToMyProjectsCommand = _navigateToMyProjectsCommand ?? new MvxCommand(DoNavigateToMyProjectCommand);
                return _navigateToMyProjectsCommand;
            }
        }

        public ObservableCollection<Project> MyProjects
        {
            get { return _myProjects; }
            set
            {
                _myProjects = value;
                base.RaisePropertyChanged(()=>MyProjects);
            }
        }

        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                if (value != null)
                {
                    NavigateToProjectView(value); 
                }
                base.RaisePropertyChanged(()=>SelectedProject);
            }
        }

        private void DoNavigateToMyProjectCommand()
        {
            ShowViewModel<ProjectListViewModel>();
        }

        public MainViewModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        public override void Start()
        {
            if (!_apiManager.IsAutorizated)
            {
                ShowViewModel<AuthViewModel>();
            }
            else
            {
                GetProjectList();
                base.Start();
            }
          
        }

        private async void GetProjectList()
        {
          var receivedProjects= (await _apiManager.GetMyProjects()).Result;
            MyProjects=new ObservableCollection<Project>();
            foreach (var receivedProject in receivedProjects)
            {
                MyProjects.Add(new Project(){Description = receivedProject.Description,Id=receivedProject.Id,Name = receivedProject.Name,ProjectUrl = receivedProject.ProjectUrl});
            }
        }

        public void NavigateToProjectView(Project selectedProject)
        {
            ShowViewModel<ProjectViewModel>(new { projectId = selectedProject.Id });
        }
    }
}
