using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired(true)
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.ExternalReference)
                .IsRequired(false)
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.CreatedAt)
                .IsRequired(true);

            builder.Property(x => x.UpdatedAt)
                .IsRequired(true);

            builder.Property(x => x.Amount)
                .IsRequired(true)
                .HasColumnType("MONEY")
                .HasMaxLength(255);

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Getaway)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);
        }
    }
}
