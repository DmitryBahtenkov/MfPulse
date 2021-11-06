using System;
using System.Collections.Generic;

namespace MfPulse.CrossCutting.Exceptions
{
    public class BusinessException : Exception
    {
        public Dictionary<string, string> Response { get; }

        public BusinessException(string message) : base(message)
        {
            Response = new Dictionary<string, string>()
            {
                {"Message", message}
            };
        }
    }
}