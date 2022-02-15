﻿using System;
using System.Net;

namespace SVPlant.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public int StatusCode { get; set; }
        public ServiceException(string message)
            : base(message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        }
    }
}
