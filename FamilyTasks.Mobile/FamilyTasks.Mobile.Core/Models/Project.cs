using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace FamilyTasks.Mobile.Core.Models
{
    public class Project:MvxNotifyPropertyChanged
    {
        private long _id;
        private string _name;
        private string _description;
        private string _projectUrl;

        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.RaisePropertyChanged(()=>Id);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                base.RaisePropertyChanged(() => Name);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                base.RaisePropertyChanged(() => Description);
            }
        }

        public string ProjectUrl
        {
            get { return _projectUrl; }
            set
            {
                _projectUrl = value;
                base.RaisePropertyChanged(() => ProjectUrl);
            }
        }
    }
}
