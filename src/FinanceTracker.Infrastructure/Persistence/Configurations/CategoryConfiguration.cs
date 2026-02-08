using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .IsRequired();

        builder.OwnsOne(e => e.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Name)
                .HasColumnName("Name")
                .HasMaxLength(SizeValues.SMALL)
                .IsRequired();
        });

        builder.OwnsOne(e => e.Color, colorBuilder =>
        {
            colorBuilder.Property(c => c.Color)
                .HasColumnName("Color")
                .HasMaxLength(SizeValues.SMALL)
                .IsRequired();
        });

        builder.OwnsOne(e => e.Icon, iconBuilder =>
        {
            iconBuilder.Property(i => i.Source)
                .HasColumnName("Icon")
                .HasMaxLength(SizeValues.SMALL)
                .IsRequired();
        });
    }
}
