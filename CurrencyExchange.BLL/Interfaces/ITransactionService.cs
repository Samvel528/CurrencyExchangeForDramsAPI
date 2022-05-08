using CurrencyExchange.BLL.DTOs;
using CurrencyExchange.DAL.Entities;
using System.Collections.Generic;

namespace CurrencyExchange.BLL.Interfaces
{
    public interface ITransactionService : IService
    {
        void CreateTransaction(TransactionDTO transactionDTO);
        Transaction GetTransactionById(int? id);
        List<Transaction> GetTransactions();
    }
}
