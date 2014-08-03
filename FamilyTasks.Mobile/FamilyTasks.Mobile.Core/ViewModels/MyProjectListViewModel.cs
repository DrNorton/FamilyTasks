using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Response;

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class MyProjectListViewModel : MvxViewModel
    {
        private readonly IApiManager _apiManager;
        private Response<List<ProjectResponse>> _myProjects;

        public MyProjectListViewModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        public Response<List<ProjectResponse>> MyProjects
        {
            get { return _myProjects; }
            set
            {
                _myProjects = value;
                base.RaisePropertyChanged(()=>MyProjects);
            }
        }

        public async override void Start()
        {
            MyProjects=await _apiManager.GetMyProjects();
            base.Start();
        }
    }
}
