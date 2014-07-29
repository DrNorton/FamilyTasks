﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FamilyTasks.Mobile.Api.Request
{
    public abstract class BaseRequest
    {
        public abstract string MethodName { get; }
        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
