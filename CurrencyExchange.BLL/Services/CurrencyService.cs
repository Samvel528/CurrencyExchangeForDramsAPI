using CurrencyExchange.BLL.Interfaces;
using CurrencyExchange.DAL.Entities;
using CurrencyExchange.DAL.Interfaces;
using System.Collections.Generic;

namespace CurrencyExchange.BLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        IUnitOfWork<Currency> _unitOfWorkCurrency { get; set; }

        public CurrencyService(IUnitOfWork<Currency> unitOfWorkCurrency)
        {
            _unitOfWorkCurrency = unitOfWorkCurrency;
        }

        public List<Currency> GetCurrencies()
        {
            List<Currency> currencies = _unitOfWorkCurrency.GetRepositoryInstance().GetAll();

            return currencies;
        }

        public void Dispose()
        {
            _unitOfWorkCurrency.Dispose();
        }
    }
}
