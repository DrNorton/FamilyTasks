using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace FamilyTasks.Mobile.Core.ViewModels.Base
{
    public class LoadingMvxViewModel:MvxViewModel
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                base.RaisePropertyChanged(()=>IsLoading);
            }
        }

        public void Wait(bool wait)
        {
            IsLoading = wait;
        }


    }
}
