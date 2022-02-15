using System;
using System.Net;

namespace SVPlant.Core.Exceptions
{
    public class PlantNotFoundException : Exception, IAppException
    {
        public int StatusCode { get; set; }
        public PlantNotFoundException(int id)
            : base($"Plant with id {id} not found in the database.")
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
