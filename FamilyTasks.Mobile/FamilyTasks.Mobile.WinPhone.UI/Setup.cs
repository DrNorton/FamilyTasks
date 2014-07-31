using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using FamilyTasks.Mobile.Core.Interfaces;
using FamilyTasks.Mobile.WinPhone.UI.Providers;
using Microsoft.Phone.Controls;

namespace FamilyTasks.Mobile.WinPhone.UI
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IMessageProvider, MessageBoxProvider>();
            return new Core.App(new SettingsService());
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}