using CurrencyExchange.BLL.Interfaces;
using CurrencyExchange.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CurrencyExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyService _currencyService;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger)
        {
            _currencyService = currencyService;
            _logger = logger;
        }

        // GET: api/<CurrencyExchangeController>
        [HttpGet]
        public IEnumerable<Currency> List()
        {
            IEnumerable<Currency> currencies = _currencyService.GetCurrencies();
            _logger.LogInformation("Get all the transacions");
            return currencies;
        }
    }
}
