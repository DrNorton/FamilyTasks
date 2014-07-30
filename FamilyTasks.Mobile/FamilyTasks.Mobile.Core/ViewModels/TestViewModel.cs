using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class TestViewModel: MvxViewModel
    {
        #region region

        private string _test="asdasdasd";

        public string Test
        {
            get { return _test; }
            set
            {
                _test = value;
                RaisePropertyChanged(() => Test);
            }
        }

        #endregion

        
    }
}
