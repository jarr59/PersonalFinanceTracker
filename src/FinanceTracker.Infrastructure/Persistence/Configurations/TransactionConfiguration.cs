using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Domain.Transaction.Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => new { x.Id, x.UserId });

        builder.Property(e => e.Id)
            .HasMaxLength(SizeValues.KEY)
            .IsRequired();

        builder.Property(e => e.UserId)
            .HasMaxLength(SizeValues.KEY)
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasPrecision(18,2)
            .IsRequired();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(SizeValues.LARGE)
            .IsRequired();

        builder.Property(e => e.Type)
            .IsRequired();
    }
}
