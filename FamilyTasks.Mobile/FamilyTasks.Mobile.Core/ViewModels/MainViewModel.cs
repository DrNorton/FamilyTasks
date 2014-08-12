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

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IApiManager _apiManager;
        private MvxCommand _navigateToMyProjectsCommand;
        private ObservableCollection<Project> _myProjects; 
    


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
            GetProjectList();
            base.Start();
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
    }
}
