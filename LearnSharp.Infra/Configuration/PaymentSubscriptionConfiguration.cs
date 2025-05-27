using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class PaymentSubscriptionConfiguration : IEntityTypeConfiguration<PaymentSubscription>
    {
        public void Configure(EntityTypeBuilder<PaymentSubscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateProcess)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.Message)
                .HasMaxLength(500);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.LinkPayment)
                .HasMaxLength(255);

            builder.Property(x => x.IdExternalPayment)
                .HasMaxLength(100);

            builder.Property(x => x.DateDue)
                .IsRequired();

            builder.HasOne(x => x.UserSubscription)
                .WithMany(x => x.PaymentSubscriptions)
                .HasForeignKey(x => x.IdUserSubscription)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}