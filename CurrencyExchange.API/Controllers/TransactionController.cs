using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CurrencyExchange.BLL.Interfaces;
using CurrencyExchange.API.Models;
using CurrencyExchange.BLL.DTOs;
using CurrencyExchange.DAL.Entities;
using CurrencyExchange.BLL.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        // GET: api/<CurrencyExchangeController>
        [HttpGet]
        public IEnumerable<Transaction> List()
        {
            IEnumerable<Transaction> transactions = _transactionService.GetTransactions();
            _logger.LogInformation("Get all the transacions");
            return transactions;
        }

        // GET api/<CurrencyExchangeController>/5
        [HttpGet("{id}")]
        public Transaction List(int id)
        {
            _logger.LogInformation($"Getting transacions by id({id})...");
            Transaction transaction = _transactionService.GetTransactionById(id);
            _logger.LogInformation($"Get transacions by id({id})");
            return transaction;
        }

        // POST api/<CurrencyExchangeController>
        [HttpPost]
        public void Create([FromBody] TransactionViewModel transactionViewModel)
        {
            try
            {
                var transactionDTO = new TransactionDTO { CurrencyCode = transactionViewModel.CurrencyCode, GivenAmount = transactionViewModel.GivenAmount };
                _transactionService.CreateTransaction(transactionDTO);
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            _logger.LogInformation("Create new transaction");
        }
    }
}
