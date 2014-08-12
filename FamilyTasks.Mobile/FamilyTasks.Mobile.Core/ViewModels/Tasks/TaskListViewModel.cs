using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Core.ViewModels.Base;
using Task = FamilyTasks.Mobile.Core.Models.Task;

namespace FamilyTasks.Mobile.Core.ViewModels.Tasks
{
    public class TaskListViewModel:LoadingMvxViewModel
    {
        private List<FamilyTasks.Mobile.Core.Models.Task> _tasks;

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
