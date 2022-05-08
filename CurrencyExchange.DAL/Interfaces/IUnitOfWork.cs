using System;

namespace CurrencyExchange.DAL.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> GetRepositoryInstance();
        void Save();
    }
}
