using CurrencyExchange.DAL.Entities;
using System.Collections.Generic;

namespace CurrencyExchange.BLL.Interfaces
{
    public interface ICurrencyService : IService
    {
        List<Currency> GetCurrencies();
    }
}
