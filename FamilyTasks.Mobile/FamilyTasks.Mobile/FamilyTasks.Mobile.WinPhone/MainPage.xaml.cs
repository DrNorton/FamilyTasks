using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using FamilyTasks.Mobile.Api;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.WinPhone.Cache;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;


namespace FamilyTasks.Mobile.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = FamilyTasks.Mobile.App.GetMainPage().ConvertPageToUIElement(this);
          GetToken();
           
        }

        private async void GetToken()
        {
            var executerService = new RequestExecuterCachedServiceDecorator(new CacheService(),new Settings.Settings());
            var ds=await executerService.Autorizate(new AutorizationRequest() { Password = "SuperPass", UserName = "andrew"});
            
        }
    }
}
