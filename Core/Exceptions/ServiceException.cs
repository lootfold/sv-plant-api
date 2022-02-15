using System;

namespace SVPlant.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message)
            : base(message)
        {

        }
    }
}
