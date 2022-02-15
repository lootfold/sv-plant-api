using System;

namespace SVPlant.Core.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
