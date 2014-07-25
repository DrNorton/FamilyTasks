using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace FamilyTasks.Api
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class HelloRequest
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    public class HelloService : Service
    {
        public object Any(HelloRequest request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }
}