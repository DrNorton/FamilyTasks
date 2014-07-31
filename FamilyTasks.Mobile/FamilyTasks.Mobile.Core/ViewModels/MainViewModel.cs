using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Core.ViewModels.Auth;

namespace FamilyTasks.Mobile.Core.ViewModels
{
    public class MainViewModel 
		: MvxViewModel
    {
        private readonly IApiManager _apiManager;

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
            base.Start();
        }
    }
}
