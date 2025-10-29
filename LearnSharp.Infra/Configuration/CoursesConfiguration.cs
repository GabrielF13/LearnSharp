using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Cover)
                .HasMaxLength(255);

            builder.Property(x => x.DateCreated)
                .IsRequired();

            builder.HasMany(x => x.Module)
                .WithOne(x => x.Course)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Subscription)
                .WithMany(x => x.Courses);
        }
    }
}