using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Settings;

namespace FamilyTasks.Mobile.Api.Tests.Stubs
{
    public class SettingsServiceStub:ISettingsService
    {
        private Token _token;
        public Uri BaseUrl
        {
            get { return new Uri(@"http://localhost:63624/"); }
        }

        public Token Token
        {
            get { return _token; }
            set { _token = value; }
        }
    }
}
