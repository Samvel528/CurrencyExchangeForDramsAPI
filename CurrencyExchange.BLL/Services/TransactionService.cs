using CurrencyExchange.BLL.BusinessModels;
using CurrencyExchange.BLL.DTOs;
using CurrencyExchange.BLL.Infrastructures;
using CurrencyExchange.BLL.Interfaces;
using CurrencyExchange.DAL.Entities;
using CurrencyExchange.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CurrencyExchange.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork<Transaction> _unitOfWorkTransaction { get; set; }
        IUnitOfWork<Currency> _unitOfWorkCurrency { get; set; }

        public TransactionService(IUnitOfWork<Transaction> unitOfWorkTransaction, IUnitOfWork<Currency> unitOfWorkCurrency)
        {
            _unitOfWorkTransaction = unitOfWorkTransaction;
            _unitOfWorkCurrency = unitOfWorkCurrency;
        }

        public void CreateTransaction(TransactionDTO transactionDTO)
        {
            Currency currency = _unitOfWorkCurrency.GetRepositoryInstance().GetByCode(c => c.Code == transactionDTO.CurrencyCode);

            if (currency == null)
                throw new ValidationException("Currency not found", "");

            (decimal, decimal) amountData = new Amount(transactionDTO.GivenAmount, currency.Type).ReceivedAmount();

            Transaction transaction = new Transaction
            {
                Id = new Guid(),
                Status = Status.Pending,
                DateOfExecution = DateTime.Now,
                CurrencyId = currency.Id,
                GivenAmount = transactionDTO.GivenAmount,
                ReceivedAmount = amountData.Item1,
                CurrentRate = amountData.Item2
            };

            _unitOfWorkTransaction.GetRepositoryInstance().Add(transaction);
            _unitOfWorkTransaction.Save();
        }

        public void Dispose()
        {
            _unitOfWorkTransaction.Dispose();
            _unitOfWorkCurrency.Dispose();
        }

        public Transaction GetTransactionById(int? id)
        {
            if (id == null)
                throw new ValidationException("Transaction Id is not entered", "");
            Transaction transaction = _unitOfWorkTransaction.GetRepositoryInstance().GetById(id.Value);
            if (transaction == null)
                throw new ValidationException("Transaction not found", "");

            return transaction;
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = _unitOfWorkTransaction.GetRepositoryInstance().GetAll();

            return transactions;
        }
    }
}