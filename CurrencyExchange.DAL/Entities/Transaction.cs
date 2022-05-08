using System;

namespace CurrencyExchange.DAL.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime DateOfExecution { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public Status Status { get; set; }
        public decimal CurrentRate { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
