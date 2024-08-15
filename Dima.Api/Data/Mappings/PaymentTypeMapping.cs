using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class PaymentTypeMapping : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentType");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CardName)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.CardType)
                .IsRequired(true)
                .HasColumnType("SMALLINT");


            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

        }
    }
}
