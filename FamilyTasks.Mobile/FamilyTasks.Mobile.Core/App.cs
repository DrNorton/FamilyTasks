using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Settings;
using FamilyTasks.Mobile.Core.Interfaces;

namespace FamilyTasks.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        private readonly ISettingsService _settingsService;

        public App(ISettingsService settingsService)
        {
            _settingsService = settingsService;
           
        }

        public override void Initialize()
        {
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();
            
            RegisterAppStart<ViewModels.MainViewModel>();
            Mvx.RegisterSingleton(typeof(ISettingsService),_settingsService);
            Mvx.RegisterType<IRequestExecuterService,RequestExecuterService>();
            Mvx.ConstructAndRegisterSingleton<IApiManager,ApiManager>();
        }
    }
}