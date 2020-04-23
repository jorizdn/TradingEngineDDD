using Microsoft.EntityFrameworkCore;
using TradingEngine.Domains;
using TradingEngine.Domains.Currency;
using TradingEngine.Domains.Entities;

namespace TradingEngine.Infrastructure
{
    public class TradingEngineContext : DbContext
    {
        public TradingEngineContext(DbContextOptions<TradingEngineContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Currency>().ToTable("Currencies");

            modelBuilder.Entity<Account>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(fk => fk.UserId)
                .HasPrincipalKey(pk => pk.Id);

            modelBuilder.Entity<Account>()
                .HasOne(p => p.Currency)
                .WithMany()
                .HasForeignKey(fk => fk.CurrencyId)
                .HasPrincipalKey(pk => pk.Id);
        }
    }
}
