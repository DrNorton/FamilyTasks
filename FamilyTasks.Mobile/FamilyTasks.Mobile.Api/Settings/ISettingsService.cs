using System;

namespace FamilyTasks.Mobile.Api.Settings
{
    public interface ISettingsService
    {
        Uri BaseUrl { get;  }
        Token Token { get; set; }
        
    }
}