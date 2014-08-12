using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Core.Models;
using FamilyTasks.Mobile.Core.ViewModels.Base;

namespace FamilyTasks.Mobile.Core.ViewModels.Projects
{
    public class ProjectListViewModel:LoadingMvxViewModel
    {
        private List<Project> _projects;
        private MvxCommand _addNewProjectCommand;

        public ICommand AddNewProjectCommand    
        {
            get
            {
                _addNewProjectCommand = _addNewProjectCommand ?? new MvxCommand(DoAddNewProjectCommandCommand);
                return _addNewProjectCommand;
            }
        }

        private void DoAddNewProjectCommandCommand()
        {
            
        }


        public List<Project> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                base.RaisePropertyChanged(()=>Projects);
            }
        }
    }
}
