using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Core.Interfaces
{
    public interface IMessageProvider
    {
       void ShowInformationMessage(string title,string message);
    }
}
