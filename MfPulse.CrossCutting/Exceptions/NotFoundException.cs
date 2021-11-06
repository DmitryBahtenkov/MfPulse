using System;

namespace MfPulse.CrossCutting.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = null) : base(message){}
    }
}