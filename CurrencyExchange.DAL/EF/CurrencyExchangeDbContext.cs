using Microsoft.EntityFrameworkCore;
using CurrencyExchange.DAL.Entities;

namespace CurrencyExchange.DAL.EF
{
    public class CurrencyExchangeDbContext : DbContext
    {
        public CurrencyExchangeDbContext(DbContextOptions<CurrencyExchangeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
