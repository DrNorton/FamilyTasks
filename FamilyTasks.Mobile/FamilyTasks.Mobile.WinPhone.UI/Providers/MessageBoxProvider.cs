using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FamilyTasks.Mobile.Core.Interfaces;

namespace FamilyTasks.Mobile.WinPhone.UI.Providers
{
    public class MessageBoxProvider:IMessageProvider
    {
        public void ShowInformationMessage(string title, string message)
        {
            MessageBox.Show(message, title,MessageBoxButton.OK);
        }
    }
}
