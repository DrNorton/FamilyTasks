using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Mobile.Api.Settings
{
    public class Token
    {
        public string Value { get; set; }
        public string TokenType { get; set; }
        public int ExpiredIn { get; set; }
    }
}
