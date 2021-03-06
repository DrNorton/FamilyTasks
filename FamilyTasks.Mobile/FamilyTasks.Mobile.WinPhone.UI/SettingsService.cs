﻿using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
            get { return GetData<Token>("token");  }
            set {SetData("token", value); }
        }

        public void SetData(string name, object value)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(name))
                settings[name] = value;
            else
                settings.Add(name, value);
            settings.Save();
        }
        public T GetData<T>(string name)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(name))
                return (T)settings[name];
            else
                return default(T);
        }


    }
}
