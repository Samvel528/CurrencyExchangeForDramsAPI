using System;
using CurrencyExchange.DAL.EF;
using CurrencyExchange.DAL.Interfaces;

namespace CurrencyExchange.DAL.Repositories
{
    public class EFUnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly CurrencyExchangeDbContext _dbContext;

        public EFUnitOfWork(CurrencyExchangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepositoryInstance()
        {
            return new GenericRepository<T>(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}
