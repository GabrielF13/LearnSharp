using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.LinkVideo)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.HasOne(x => x.Module)
                .WithMany(x => x.Classes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.userClassCompleteds)
                .WithOne(x => x.Class)
                .HasForeignKey(x => x.IdClass)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}