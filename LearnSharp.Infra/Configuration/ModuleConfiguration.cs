using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.DateCreated)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Module)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Classes)
                .WithOne(x => x.Module)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}