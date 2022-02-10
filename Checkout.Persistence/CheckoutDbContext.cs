using Checkout.Domain.PaymentModule.Entities;
using Checkout.Helper.Configuration;
using Checkout.Helper.Constants;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence
{
    public class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext(
            DbContextOptions<CheckoutDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payments => Set<Payment>();

        public virtual DbSet<PaymentCard> PaymentCards => Set<PaymentCard>();

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable(PaymentTableNames.Payment, SchemaNames.Payment);
            modelBuilder.Entity<PaymentCard>().ToTable(PaymentTableNames.PaymentCard, SchemaNames.Payment);
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConfigurationSettings.DbConnectionString);
        }
    }
}
