using System;

namespace FamilyTasks.Mobile.Api.Settings
{
    public interface ISettings
    {
        Uri BaseUrl { get;  }
        Token Token { get; set; }
        
    }
}