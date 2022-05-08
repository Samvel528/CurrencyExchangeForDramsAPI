using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CurrencyExchange.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByCode(Expression<Func<T, bool>> predicate);
        void Add(T entity);
    }
}
