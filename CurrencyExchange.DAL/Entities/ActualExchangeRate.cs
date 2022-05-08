using System;
using System.Collections.Generic;

namespace CurrencyExchange.DAL.Entities
{
    public class ActualExchangeRate
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
