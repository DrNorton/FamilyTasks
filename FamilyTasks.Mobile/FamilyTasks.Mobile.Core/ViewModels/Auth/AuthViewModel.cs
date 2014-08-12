using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Core.Interfaces;
using FamilyTasks.Mobile.Core.ViewModels.Base;

namespace FamilyTasks.Mobile.Core.ViewModels.Auth
{
    public class AuthViewModel : LoadingMvxViewModel
    {
        private readonly IApiManager _apiManager;
        private readonly IMessageProvider _messageProvider;
        private string _password;
        private string _login;


        private MvxCommand _navigateToRegisterCommand;

        public ICommand NavigateToRegisterCommand
        {
            get
            {
                _navigateToRegisterCommand = _navigateToRegisterCommand ?? new MvxCommand(NavigateToRegister);
                return _navigateToRegisterCommand;
            }
        }

        private void NavigateToRegister()
        {
            ShowViewModel<RegisterViewModel>();
        }

        private MvxCommand _navigateToRecoveryPasswordCommand;

        public ICommand NavigateToRecoveryPasswordCommand
        {
            get
            {
                _navigateToRecoveryPasswordCommand = _navigateToRecoveryPasswordCommand ?? new MvxCommand(DoNavigateToRecoveryPasswordCommand);
                return _navigateToRecoveryPasswordCommand;
            }
        }

        private void DoNavigateToRecoveryPasswordCommand()
        {
            ShowViewModel<RecoveryViewModel>();
        }


     

        private MvxCommand _authCommand ;

        public ICommand AuthCommand
        {
            get
            {
                _authCommand = _authCommand ?? new MvxCommand(Auth);
                return _authCommand;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

              base.RaisePropertyChanged(()=>Password);
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                base.RaisePropertyChanged(()=>Login);
            }
        }


        public AuthViewModel(IApiManager apiManager,IMessageProvider messageProvider)
        {
            _apiManager = apiManager;
            _messageProvider = messageProvider;
        }

        private async void Auth()
        {
            Wait(true);
            var result=await _apiManager.Autorizate(new AutorizationRequest(Login, Password));
            Wait(false);
            if (result.ErrorCode == 0)
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _messageProvider.ShowInformationMessage("Ошибка авторизации",result.ErrorMessage);
            }
        }

      

        
    }

    
}
