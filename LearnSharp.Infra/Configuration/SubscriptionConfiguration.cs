using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.HasMany(x => x.UserSubscriptions)
                .WithOne(x => x.Subscription)
                .HasForeignKey(x => x.IdSubscription)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Courses)
                .WithMany(x => x.Subscription);
        }
    }
}