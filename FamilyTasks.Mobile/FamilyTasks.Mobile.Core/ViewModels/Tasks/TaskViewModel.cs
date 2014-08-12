using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Core.ViewModels.Base;

namespace FamilyTasks.Mobile.Core.ViewModels.Tasks
{
    public class TaskViewModel:LoadingMvxViewModel
    {
        public Models.Task Task { get; set; }
    }
}
