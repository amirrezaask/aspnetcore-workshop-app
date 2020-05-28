using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Frontend.Services
{
    public class ServiceError : Exception
    {
        public ServiceError(string msg) : base ($"Service Error {msg}")
        {

        }
    }
}
