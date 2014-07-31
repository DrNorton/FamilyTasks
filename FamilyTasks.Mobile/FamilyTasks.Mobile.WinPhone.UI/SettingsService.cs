using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Settings;

namespace FamilyTasks.Mobile.WinPhone.UI
{
    public class SettingsService:ISettingsService
    {
        private Token _token;
        public Uri BaseUrl
        {
            get { return new Uri(@"http://familytasksapi.azurewebsites.net/"); }
        }

        public Token Token
        {
            get { return _token; }
            set { _token = value; }
        }
    }
}
