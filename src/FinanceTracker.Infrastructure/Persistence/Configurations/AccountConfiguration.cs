using FinanceTracker.Domain.Accounts;
using FinanceTracker.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasMaxLength(SizeValues.KEY)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(SizeValues.SMALL)
            .IsRequired();

        builder.Property(e => e.Balance)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(e => e.Currency)
            .HasMaxLength(SizeValues.SMALL)
            .IsRequired();

        builder.Property(e => e.Icon)
            .HasMaxLength(SizeValues.SMALL)
            .IsRequired();

        builder.Property(e => e.Color)
            .HasMaxLength(SizeValues.SMALL)
            .IsRequired();
    }
}