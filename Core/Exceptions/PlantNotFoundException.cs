using System;

namespace SVPlant.Core.Exceptions
{
    public class PlantNotFoundException : Exception
    {
        public PlantNotFoundException(int id)
            : base($"Plant with id {id} not found in the database.")
        {
        }
    }
}
