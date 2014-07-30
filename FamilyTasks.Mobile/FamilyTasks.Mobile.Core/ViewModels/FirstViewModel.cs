using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        #region region command

        private MvxCommand _navigationCommand;

        public ICommand NavigationCommand
        {
            get
            {
                _navigationCommand = _navigationCommand ?? new MvxCommand(DoNavigationCommand);
                return _navigationCommand;
            }
        }

        private void DoNavigationCommand()
        {
            ShowViewModel<TestViewModel>();
        }

        #endregion
    }
}
