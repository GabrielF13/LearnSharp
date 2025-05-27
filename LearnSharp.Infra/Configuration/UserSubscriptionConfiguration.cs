using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.DateStart)
                .IsRequired();

            builder.Property(x => x.DateDue)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserSubscriptions)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subscription)
                .WithMany(x => x.UserSubscriptions)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PaymentSubscriptions)
                .WithOne(x => x.UserSubscription)
                .HasForeignKey(x => x.IdUserSubscription)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}