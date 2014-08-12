using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Core.Models;
using FamilyTasks.Mobile.Core.ViewModels.Base;
using Task = FamilyTasks.Mobile.Core.Models.Task;

namespace FamilyTasks.Mobile.Core.ViewModels.Projects
{
    public class ProjectViewModel:LoadingMvxViewModel
    {
        private Project _project;
        private List<User> _users;
        private List<Models.Task> _tasks; 

        public Models.Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                base.RaisePropertyChanged(()=>Project);
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                base.RaisePropertyChanged(()=>Users);
            }
        }

        public List<Task> Tasks
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
