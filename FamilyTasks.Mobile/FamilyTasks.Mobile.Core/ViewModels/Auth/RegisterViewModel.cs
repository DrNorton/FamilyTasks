using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Core.Interfaces;

namespace FamilyTasks.Mobile.Core.ViewModels.Auth
{
    public class RegisterViewModel: MvxViewModel
    {
        private readonly IApiManager _apiManager;
        private readonly IMessageProvider _messageProvider;
        private RegisterModel _registerInfoModel;
        private MvxCommand _registerCommand;

        public ICommand RegisterCommand
        {
            get
            {
                _registerCommand = _registerCommand ?? new MvxCommand(Register);
                return _registerCommand;
            }
        }

        public RegisterViewModel(IApiManager apiManager,IMessageProvider messageProvider)
        {
            _apiManager = apiManager;
            _messageProvider = messageProvider;
            _registerInfoModel=new RegisterModel();
        }

        private async void Register()
        {
            var result = await
                    _apiManager.Register(new RegistrationRequest()
                    {
                        ConfirmPassword = RegisterInfoModel.ConfirmPassword,
                        Phone = RegisterInfoModel.Phone,
                        Password = RegisterInfoModel.Password
                    });
            if (result.ErrorCode == 0)
            {
                ShowViewModel<AuthViewModel>();
            }
            else
            {
                _messageProvider.ShowInformationMessage("ошибка регистрации",result.ErrorMessage);
            }


        }
        public RegisterModel RegisterInfoModel
        {
            get { return _registerInfoModel; }
            set
            {
                _registerInfoModel = value;
                RaisePropertyChanged(() => RegisterInfoModel);
            }
        }
    }

    public class RegisterModel:MvxNotifyPropertyChanged
    {
        private string _password;
        private string _phone;
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged(() => ConfirmPassword);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                base.RaisePropertyChanged(() => Password);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                base.RaisePropertyChanged(() => Phone);
            }
        }
    }
}
